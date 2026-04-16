using EasyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTY.HookTest
{
  public partial class Form1 : Form
  {
    private readonly TransferProxy _proxy = new TransferProxy();
    private string _selectedGamePath;
    private bool _pipeLoopStarted;
    private Process _gameProcess;
    private bool _proxyStarting;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      AppendLog("========== 程序启动 ==========");
      
      Task.Run(() =>
      {
        try
        {
          AppendLog("正在尝试启用网络代理服务……");
          _proxyStarting = true;
          Invoke(new Action(() => UpdateProxyStatus()));
          _proxy.Start();
          AppendLog("✅ 代理服务已启动");
          AppendLog($"   UDP代理端口: {_proxy.UdpProxyPort}");
          AppendLog($"   TCP代理端口: {_proxy.TcpProxyPort}");
          AppendLog($"   虚拟IP: {_proxy.VirtualIp}");
        }
        catch (Exception ex)
        {
          AppendLog($"❌ 代理服务启动失败: {ex.Message}");
        }
        finally
        {
          _proxyStarting = false;
          Invoke(new Action(() => UpdateProxyStatus()));
        }
      });
      
      if (!_pipeLoopStarted)
      {
        _pipeLoopStarted = true;
        Task.Run(() => PipeLoop());
        AppendLog("✅ 命名管道服务已启动");
      }
      
      AppendLog("请点击上方按钮选择游戏可执行文件");
      
      Task.Run(() => MonitorGameProcess());
    }
    
    private async Task MonitorGameProcess()
    {
      while (true)
      {
        await Task.Delay(500);
        try
        {
          Invoke(new Action(() =>
          {
            UpdateButtonStates();
            UpdateStatusLabel();
            UpdateProxyStatus();
          }));
        }
        catch
        {
        }
      }
    }
    
    private void UpdateProxyStatus()
    {
      if (_proxyStarting || _proxy.State == TransferProxy.ProxyState.Starting)
      {
        lblProxyStatus.Text = "正在启用网络代理";
        lnkProxyAction.Visible = false;
        return;
      }
      
      if (_proxy.State == TransferProxy.ProxyState.Started)
      {
        var virtualIpStr = $"{(_proxy.VirtualIp >> 24) & 0xFF}.{(_proxy.VirtualIp >> 16) & 0xFF}.{(_proxy.VirtualIp >> 8) & 0xFF}.{_proxy.VirtualIp & 0xFF}";
        lblProxyStatus.Text = $"代理已启用 UDP: {_proxy.UdpProxyPort} | TCP: {_proxy.TcpProxyPort} | {virtualIpStr}";
        lnkProxyAction.Visible = true;
        lnkProxyAction.Text = "停止";
        return;
      }
      
      lblProxyStatus.Text = "网络代理未启动";
      lnkProxyAction.Visible = true;
      lnkProxyAction.Text = "启动";
    }
    
    private void LnkProxyAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (_proxy.State == TransferProxy.ProxyState.Started)
      {
        _proxy.Close();
        AppendLog("已停止网络代理服务");
        UpdateProxyStatus();
      }
      else
      {
        Task.Run(() =>
        {
          try
          {
            AppendLog("正在尝试启用网络代理服务……");
            _proxyStarting = true;
            Invoke(new Action(() => UpdateProxyStatus()));
            _proxy.Start();
            AppendLog("✅ 代理服务已启动");
            AppendLog($"   UDP代理端口: {_proxy.UdpProxyPort}");
            AppendLog($"   TCP代理端口: {_proxy.TcpProxyPort}");
            AppendLog($"   虚拟IP: {_proxy.VirtualIp}");
          }
          catch (Exception ex)
          {
            AppendLog($"❌ 代理服务启动失败: {ex.Message}");
          }
          finally
          {
            _proxyStarting = false;
            Invoke(new Action(() => UpdateProxyStatus()));
          }
        });
      }
    }
    
    private void UpdateButtonStates()
    {
      var isRunning = IsGameRunning();
      btnCloseGame.Enabled = isRunning;
      btnStartGame.Enabled = !isRunning && !string.IsNullOrEmpty(_selectedGamePath);
    }
    
    private void BtnSelectGame_Click(object sender, EventArgs e)
    {
      if (IsGameRunning())
      {
        MessageBox.Show(
          "请先关闭当前正在运行的游戏进程，再选择其他可执行文件。",
          "游戏正在运行",
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
        return;
      }
      
      using (var openFileDialog = new OpenFileDialog())
      {
        openFileDialog.Filter = "可执行文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
        openFileDialog.Title = "选择帝国时代2可执行文件";
        openFileDialog.FileName = "age2_x1.exe";
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          _selectedGamePath = openFileDialog.FileName;
          UpdateStatusLabel();
          UpdateButtonStates();
          AppendLog($"✅ 已选择游戏文件: {_selectedGamePath}");
          AppendLog("请点击「启动游戏」按钮开始游戏");
        }
      }
    }
    
    private void BtnStartGame_Click(object sender, EventArgs e)
    {
      var existingProcess = FindExistingGameProcess();
      if (existingProcess != null)
      {
        var result = MessageBox.Show(
          $"检测到游戏进程已在运行 (PID: {existingProcess.Id})\n\n是否关闭现有进程后重新启动？",
          "游戏已运行",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
          try
          {
            existingProcess.Kill();
            existingProcess.WaitForExit(3000);
            AppendLog($"✅ 已关闭现有游戏进程 (PID: {existingProcess.Id})");
          }
          catch (Exception ex)
          {
            AppendLog($"❌ 关闭进程失败: {ex.Message}");
            return;
          }
        }
        else
        {
          AppendLog("用户取消操作");
          return;
        }
      }
      
      StartGameAndInject();
    }
    
    private void BtnCloseGame_Click(object sender, EventArgs e)
    {
      var process = FindExistingGameProcess();
      if (process == null)
      {
        AppendLog("❌ 未找到正在运行的游戏进程");
        return;
      }
      
      try
      {
        AppendLog($"正在关闭游戏进程 (PID: {process.Id})...");
        process.Kill();
        process.WaitForExit(3000);
        _gameProcess = null;
        AppendLog($"✅ 游戏进程已关闭");
        UpdateStatusLabel();
        UpdateButtonStates();
      }
      catch (Exception ex)
      {
        AppendLog($"❌ 关闭游戏进程失败: {ex.Message}");
      }
    }
    
    private Process FindExistingGameProcess()
    {
      if (string.IsNullOrEmpty(_selectedGamePath))
        return null;
      
      var fileName = Path.GetFileNameWithoutExtension(_selectedGamePath);
      var processes = Process.GetProcessesByName(fileName);
      
      foreach (var process in processes)
      {
        try
        {
          if (string.Equals(process.MainModule?.FileName, _selectedGamePath, StringComparison.OrdinalIgnoreCase))
          {
            return process;
          }
        }
        catch
        {
        }
      }
      
      return null;
    }
    
    private void UpdateStatusLabel()
    {
      if (string.IsNullOrEmpty(_selectedGamePath))
      {
        toolStripStatusLabel1.Text = "未选择游戏文件";
        return;
      }
      
      var isRunning = IsGameRunning();
      var status = isRunning ? "(已启动)" : "(未启动)";
      toolStripStatusLabel1.Text = $"{_selectedGamePath} {status}";
    }
    
    private bool IsGameRunning()
    {
      if (_gameProcess != null)
      {
        try
        {
          _gameProcess.Refresh();
          if (!_gameProcess.HasExited)
            return true;
        }
        catch
        {
        }
        _gameProcess = null;
      }
      
      return FindExistingGameProcess() != null;
    }
    
    private void StartGameAndInject()
    {
      if (string.IsNullOrEmpty(_selectedGamePath))
      {
        AppendLog("❌ 错误: 请先选择游戏文件！");
        return;
      }
      
      if (!File.Exists(_selectedGamePath))
      {
        AppendLog($"❌ 错误: 找不到游戏文件: {_selectedGamePath}");
        return;
      }
      
      var dllPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "age2x1injector.dll");
      AppendLog($"注入DLL路径: {dllPath}");
      
      if (!File.Exists(dllPath))
      {
        AppendLog($"❌ 错误: 找不到注入DLL: {dllPath}");
        return;
      }
      
      var injectArgs = new InjectArgs
      {
        DllPath = dllPath,
        UdpProxyPort = _proxy.UdpProxyPort,
        TcpProxyPort = _proxy.TcpProxyPort,
        VirtualIp = _proxy.VirtualIp,
      };
      
      AppendLog($"UDP代理端口: {injectArgs.UdpProxyPort}");
      AppendLog($"TCP代理端口: {injectArgs.TcpProxyPort}");
      AppendLog($"虚拟IP: {injectArgs.VirtualIp}");
      AppendLog("正在启动游戏并注入DLL...");
      
      int pid = -1;
      
      try
      {
        RemoteHooking.CreateAndInject(_selectedGamePath, "-NoStartup", 0, injectArgs.DllPath, injectArgs.DllPath, out pid, injectArgs);
        AppendLog($"✅ 注入成功！游戏进程ID: {pid}");
        
        _gameProcess = Process.GetProcessById(pid);
        AppendLog($"   进程名称: {_gameProcess.ProcessName}");
        AppendLog($"   进程路径: {_gameProcess.MainModule?.FileName ?? "未知"}");
        AppendLog($"   主窗口句柄: {(_gameProcess.MainWindowHandle != IntPtr.Zero ? _gameProcess.MainWindowHandle.ToString() : "无")}");
        
        UpdateStatusLabel();
        UpdateButtonStates();
        
        Task.Delay(2000).ContinueWith(t =>
        {
          try
          {
            var p = Process.GetProcessById(pid);
            if (p.MainWindowHandle == IntPtr.Zero)
            {
              AppendLog("⚠️  警告: 游戏进程已启动但主窗口未显示");
            }
            UpdateStatusLabel();
            UpdateButtonStates();
          }
          catch (ArgumentException)
          {
            AppendLog("❌ 错误: 游戏进程已退出！");
            _gameProcess = null;
            UpdateStatusLabel();
            UpdateButtonStates();
          }
        });
        
        AppendLog("========== 等待游戏连接 ==========");
      }
      catch (Exception ex)
      {
        AppendLog($"❌ 注入失败: {ex.Message}");
        AppendLog($"堆栈跟踪: {ex.StackTrace}");
        return;
      }
    }
    
    private void AppendLog(string message)
    {
      if (richTextBox1.InvokeRequired)
      {
        richTextBox1.Invoke(new Action(() => AppendLog(message)));
        return;
      }
      
      var logMessage = $"[{DateTime.Now:HH:mm:ss.fff}] {message}\n";
      richTextBox1.AppendText(logMessage);
      
      if (chkAutoScroll.Checked)
      {
        richTextBox1.ScrollToCaret();
      }
    }


    private async Task PipeLoop()
    {
      while (true)
      {
        try
        {
          using (var pipe = new NamedPipeServerStream("HookPipe", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
          {
            await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
            using (var sr = new StreamReader(pipe))
            {
              string line;
              while ((line = await sr.ReadLineAsync()) != null)
              {
                AppendLog(line);
              }
            }
          }
        }
        catch (Exception ex)
        {
          try
          {
            AppendLog($"❌ 管道错误: {ex.Message}");
          }
          catch
          {
          }
          await Task.Delay(1000);
        }
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      _proxy.Close();
    }
  }
}

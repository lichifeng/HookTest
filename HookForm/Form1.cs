using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyHook;
using System.IO;
using System.IO.Pipes;
using System.Net.Sockets;
using System.Net;

namespace YTY.HookTest
{
  public partial class Form1 : Form
  {
    private readonly TransferProxy _proxy = new TransferProxy();
    private string _selectedGamePath;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // _proxy.Start();
      
      AppendLog("========== 程序启动 ==========");
      AppendLog("请点击上方按钮选择游戏可执行文件");
    }
    
    private void BtnSelectGame_Click(object sender, EventArgs e)
    {
      using (var openFileDialog = new OpenFileDialog())
      {
        openFileDialog.Filter = "可执行文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
        openFileDialog.Title = "选择帝国时代2可执行文件";
        openFileDialog.FileName = "age2_x1.exe";
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          _selectedGamePath = openFileDialog.FileName;
          toolStripStatusLabel1.Text = _selectedGamePath;
          AppendLog($"✅ 已选择游戏文件: {_selectedGamePath}");
          
          StartGameAndInject();
        }
      }
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
      
      try
      {
        RemoteHooking.CreateAndInject(_selectedGamePath, null, 0, injectArgs.DllPath, injectArgs.DllPath, out var pid, injectArgs);
        AppendLog($"✅ 注入成功！游戏进程ID: {pid}");
        AppendLog("========== 等待游戏连接 ==========");
      }
      catch (Exception ex)
      {
        AppendLog($"❌ 注入失败: {ex.Message}");
        AppendLog($"堆栈跟踪: {ex.StackTrace}");
        return;
      }
      
      PipeLoop();
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
      richTextBox1.ScrollToCaret();
    }


    private async Task PipeLoop()
    {
      while (true)
      {
        using (var pipe = new NamedPipeServerStream("HookPipe", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
        {
          await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
          using (var sr = new StreamReader(pipe))
          {
            string line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
              richTextBox1.AppendText(line + '\n');
            }
          }
        }
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      _proxy.Close();
    }
  }
}

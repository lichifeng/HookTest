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

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // _proxy.Start();
      
      AppendLog("========== 程序启动 ==========");
      AppendLog("正在读取帝国时代2安装路径...");
      
      var exePath = (string)Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0").GetValue("EXE Path");
      AppendLog($"注册表读取到的路径: {exePath}");
      
      if (string.IsNullOrEmpty(exePath))
      {
        AppendLog("❌ 错误: 无法读取帝国时代2安装路径！");
        AppendLog("请确保已安装帝国时代2：征服者");
        return;
      }
      
      var gameExePath = Path.Combine(exePath, @"age2_x1\age2_x1.exe");
      AppendLog($"游戏完整路径: {gameExePath}");
      
      if (!File.Exists(gameExePath))
      {
        AppendLog($"❌ 错误: 找不到游戏文件: {gameExePath}");
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
        RemoteHooking.CreateAndInject(gameExePath, null, 0, injectArgs.DllPath, injectArgs.DllPath, out var pid, injectArgs);
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
      using (var pipe = new NamedPipeServerStream("HookPipe", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
      {
        await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
        PipeLoop();
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

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      _proxy.Close();
    }
  }
}

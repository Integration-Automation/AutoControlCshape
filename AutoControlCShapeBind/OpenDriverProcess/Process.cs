using System.Diagnostics;

namespace AutoControlCShapeBind.OpenDriverProcess;

public class DriverProcess
{

    private ProcessStartInfo? _processStartInfo;
    private Process? _process;

    public void StartDiver(string driverPath)
    {
        _processStartInfo = new ProcessStartInfo(driverPath)
        {
            UseShellExecute = false,
            CreateNoWindow = true
        };
        _process = Process.Start(_processStartInfo);
    }
    
    public void StartDiver(string driverPath, string param)
    {
        
        _processStartInfo = new ProcessStartInfo(driverPath, param)
        {
            UseShellExecute = false,
            CreateNoWindow = true
        };
        _process = Process.Start(_processStartInfo);
    }

    public void Close()
    {
        var processes = Process.GetProcessesByName("generate_autocontrol_driver_win");
        foreach (var process in processes)
        {
            process.CloseMainWindow();
            process.Kill();
            process.Close();
        }
    }
    
}
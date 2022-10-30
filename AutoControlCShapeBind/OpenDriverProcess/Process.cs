using System.Diagnostics;

namespace AutoControlCShapeBind.OpenDriverProcess;

public class DriverProcess
{

    private static Process? _process;

    public void StartDiver(string driverPath)
    {
        _process = Process.Start(driverPath);
    }
    
    public void StartDiver(string driverPath, String param)
    {
        _process = Process.Start(driverPath, param);
    }

    public void Close()
    {
        _process?.Close();
    }
    
}
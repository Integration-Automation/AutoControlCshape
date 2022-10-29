using System.Diagnostics;

namespace AutoControlCshape.OpenDriverProcess;

public class OpenDriverProcess
{

    private Process _process;
    
    public OpenDriverProcess(String driverPath)
    {
        _process = Process.Start(driverPath);
    }
    
    public OpenDriverProcess(String driverPath, String param)
    {
        _process = Process.Start(driverPath, param);
    }

    public void Close()
    {
        _process.Close();
    }
    
}
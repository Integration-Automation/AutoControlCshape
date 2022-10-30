using AutoControlCShapeBind.OpenDriverProcess;
using AutoControlCShapeBind.Socket;

namespace AutoControlCShapeBind.DriverManager;

public class Driver
{

    private ClientSocket _clientSocket ;
    private DriverProcess _driverProcess = new();
    private string _driverPath;

    public Driver(string serverHost, int serverPort, string driverPath, string platform)
    {
        _driverPath = driverPath;
        SetDriver(platform);
        _clientSocket = new ClientSocket(serverHost, serverPort);
        _driverProcess?.StartDiver(_driverPath);
    }
    
    public Driver(string serverHost, int serverPort, string driverPath, string param, string platform)
    {
        _driverPath = driverPath;
        _clientSocket = new ClientSocket(serverHost, serverPort);
        SetDriver(platform);
        _driverProcess?.StartDiver(_driverPath, param);
    }

    private string SetDriver(string platform)
    {
        switch (platform)
        {
            case "windows":
                if (_driverPath.Equals(""))
                    _driverPath = Directory.GetCurrentDirectory() + "\\generate_autocontrol_driver_win.exe";
                break;
            case "linux":
                if (_driverPath.Equals(""))
                    _driverPath = Directory.GetCurrentDirectory() + "\\generate_autocontrol_driver_linux.exe";
                break;
            case "macos":
                if (_driverPath.Equals(""))
                    _driverPath = Directory.GetCurrentDirectory() + "\\generate_autocontrol_driver_macos.exe";
                break;
        }
        return _driverPath;
    }
    

    public string SendCommand(string dataToSend)
    {
        int retryCount = 5;
        while (retryCount > 0)
        {
            try
            {
                return _clientSocket.SendData(dataToSend);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Console.Error.WriteLine("Driver not ready {0}", dataToSend);
                retryCount -= 1;
            }
        }
        return "";
    }

    public void Quit()
    {
        _clientSocket.CloseClient();
        _driverProcess.Close();
    }
    
}
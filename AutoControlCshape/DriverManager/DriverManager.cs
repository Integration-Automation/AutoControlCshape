namespace AutoControlCshape.DriverManager;

public class DriverManager
{

    private String driverPath;
    private String host;
    private int port;
    
    public DriverManager(String serverHost, int serverPort, String driverPath)
    {
        this.driverPath = driverPath;
        SetDriver(serverHost, serverPort);
    }

    private String SetDriver(String serverHost, int serverPort)
    {
        if (this.driverPath.Equals(""))
        {
            this.driverPath = Directory.GetCurrentDirectory() + "/generate_autocontrol_driver_win64.exe";
        }
        host = serverHost;
        port = serverPort;
        return driverPath;
    }
    
}
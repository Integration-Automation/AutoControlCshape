namespace AutoControlCshape.Socket;

public class ClientSocket
{
    private System.Net.Sockets.Socket _socket;
    private String host;
    private int port;

    public ClientSocket()
    {
        
    }

    public void CloseClient()
    {
        _socket.Close();
    }
}
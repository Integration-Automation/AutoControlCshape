﻿using System.Net.Sockets;
using System.Text;

namespace AutoControlCShapeBind.Socket;

public class ClientSocket
{
    private TcpClient? _tcpClient;
    private NetworkStream? _networkStream;
    private StreamWriter? _streamWriter;
    private StreamReader? _streamReader;
    private readonly string? _host;
    private readonly int _port;

    public ClientSocket(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public string SendData(string dataToSend)
    {
        var retry = true;
        var retryCount = 5;
        var stringBuilder = new StringBuilder();
        while (retry && retryCount > 0)
        {
            try
            {
                if (_host != null)
                    _tcpClient = new TcpClient(_host, _port);
                else
                    throw new SystemException("Can't init DriverManager");
                _networkStream = _tcpClient.GetStream();
                _streamWriter = new StreamWriter(_networkStream) { NewLine = "\r\n", AutoFlush = true };
                _streamWriter.WriteLine(dataToSend);
                retry = false;
                if (!dataToSend.Equals("quit_server"))
                {
                    _streamReader = new StreamReader(_networkStream);
                    var readData = _streamReader.ReadLine();
                    while (readData != null && !readData.Equals("Return_Data_Over_JE"))
                    {
                        Console.WriteLine(readData);
                        stringBuilder.Append(readData);
                        readData = _streamReader.ReadLine();
                    }
                }
                CloseClient();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Console.Error.WriteLine("Can't send {0} will retry",  dataToSend);
                retryCount -= 1;
            }
        }
        return stringBuilder.ToString();
    }
    
    
    public void CloseClient()
    {
        _streamReader?.Close();
        _networkStream?.Close();
        _tcpClient?.Close();
    }
}
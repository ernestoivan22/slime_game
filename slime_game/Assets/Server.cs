using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


public class Server {
	TcpListener serverSocket;
	TcpClient clientSocket;
	ASCIIEncoding encoder;
	NetworkStream networkStream;
	bool connected = false;

	public Server() {
		try {
			/* Initializes the Listener */
			/*IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
			Socket listener = new Socket(AddressFamily.InterNetwork,
			                            SocketType.Stream, ProtocolType.Tcp );
			listener.Bind(localEndPoint);
			listener.Listen(10);
			Debug.Log("Waiting for a connection...");
			Socket handler = listener.Accept();*/
			serverSocket = new TcpListener(1024);
			clientSocket = default(TcpClient);
			/* Start Listeneting at the specified port */        

			serverSocket.Start();
			Debug.Log("The server is running at port 1024...");
			Debug.Log("Waiting for a connection.....");

			clientSocket = serverSocket.AcceptTcpClient();
			connected = true;

			encoder = new ASCIIEncoding();
		}
		catch (Exception e) {
			Debug.Log("Error..... " + e.StackTrace);
		}
	}

	public String receiveData() {
		networkStream = clientSocket.GetStream();
		byte[] bytesFrom = new byte[1024];
		networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
		String dataFromClient = encoder.GetString (bytesFrom);
		dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

		Console.WriteLine("Client request: " + dataFromClient);

		Byte[] sendBytes = encoder.GetBytes("ok$");
		networkStream.Write(sendBytes, 0, sendBytes.Length);
		networkStream.Flush();

		return dataFromClient;
	}

	public String sendData(String data) {
		Byte[] sendBytes = encoder.GetBytes(data);
		networkStream.Write(sendBytes, 0, sendBytes.Length);
		networkStream.Flush();

		// Respuesta del servidor
		byte[] inStream = new byte[1024];
		networkStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
		String response = encoder.GetString (inStream);
		Console.WriteLine("Client response: " + response);

		return response;
	}

	public void closeConnection() {
		/* clean up */
		clientSocket.Close();
		serverSocket.Stop();
	}
}

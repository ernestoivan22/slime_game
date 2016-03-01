using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Client {
	TcpClient clientSocket;
	NetworkStream serverStream;
	ASCIIEncoding encoder;
	bool connected = false;

	public Client(string server_adress) {
		try {
			clientSocket = new TcpClient ();

			Console.WriteLine ("Connecting.....");
			clientSocket.Connect (server_adress, 8001);
			connected = true;
			Console.WriteLine ("Connected");

			encoder = new ASCIIEncoding();
		} catch (Exception e) {
			Console.WriteLine("Error..... " + e.StackTrace);
		}
	}

	public String sendData(String data) {
		serverStream = clientSocket.GetStream();

		byte[] outStream = encoder.GetBytes(data + "$");;
		Console.WriteLine("Transmitting.....");
		serverStream.Write(outStream, 0, outStream.Length);
		serverStream.Flush();

		// Respuesta del servidor
		byte[] inStream = new byte[1024];
		serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
		String response = encoder.GetString (inStream);
		Console.WriteLine("Server response: " + response);

		return response;
	}


	public String receiveData() {
		// Respuesta del servidor
		byte[] inStream = new byte[1024];
		serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
		String response = encoder.GetString (inStream);
		response = response.Substring(0, response.IndexOf("$"));

		Console.WriteLine("Server response: " + response);

		// Ack
		serverStream = clientSocket.GetStream();
		byte[] outStream = encoder.GetBytes("ok$");;
		serverStream.Write(outStream, 0, outStream.Length);
		serverStream.Flush();

		return response;
	}

	public bool getConnected(){
		return connected;
	}
	
}

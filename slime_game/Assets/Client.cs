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

			Debug.Log ("Connecting.....");
			clientSocket.Connect (server_adress, 1024);
			connected = true;
			Debug.Log ("Connected");

			encoder = new ASCIIEncoding();
		} catch (Exception e) {
			Debug.Log("Error..... " + e.StackTrace);
		}
	}

	public String sendData(String data) {
		try{
			serverStream = clientSocket.GetStream();
			Debug.Log("Transmitting: " + data);
			byte[] outStream = encoder.GetBytes(data);;

			serverStream.Write(outStream, 0, outStream.Length);
			serverStream.Flush();
			
			// Respuesta del servidor
			/**
			byte[] inStream = new byte[1024];
			serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
			String response = encoder.GetString (inStream);
			Console.WriteLine("Server response: " + response);
			**/
			
			return "";
		}catch (Exception e) {
			Debug.Log("Error..... " + e.StackTrace);
			return ("Error..... " + e.StackTrace);
		}

	}


	public String receiveData() {
		try{
			// Respuesta del servidor
			byte[] inStream = new byte[1024];
			serverStream.Read(inStream, 0, inStream.Length);
			String response = encoder.GetString (inStream);
			
			Console.WriteLine("Server response: " + response);
			
			// Ack
			/**
			serverStream = clientSocket.GetStream();
			byte[] outStream = encoder.GetBytes("ok$");;
			serverStream.Write(outStream, 0, outStream.Length);
			serverStream.Flush();
			**/
			return response;
		}catch (Exception e) {
			Debug.Log("Error..... " + e.StackTrace);
			return ("Error..... " + e.StackTrace);
		}

	}

	public bool getConnected(){
		return connected;
	}
	
}

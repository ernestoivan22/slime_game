using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System;

public class socketController1 : MonoBehaviour {
	static bool creado = false;
	static Server tcpServer;
	float p1VelocityX, p1VelocityY, p2VelocityX = 0, p2VelocityY = 0;

	private bool mRunning;
	Thread mThread;
	//TcpListener tcp_Listener = null;
	// Use this for initialization
	void Start () {
		if (creado == false) {
			/*miServer = new Server();
			Application.LoadLevel(1);
			creado = true;		*/
			mRunning = true;
			ThreadStart ts = new ThreadStart(threadServer);
			mThread = new Thread(ts);
			mThread.Start();
			print("Thread done...");
		}
	}

	void OnApplicationQuit() {
		Debug.Log("Application exit");
		mRunning = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void threadServer()
	{
		tcpServer = new Server();
		creado = true;
		string data;
		string[] clientResponse;

		while (mRunning) {
			data = tcpServer.receiveData();
			Debug.Log (data);
			clientResponse = data.Split(' ');
			p2VelocityX = float.Parse(clientResponse[0]);
			p2VelocityY = float.Parse(clientResponse[1]);
			Debug.Log  ("p2VelocityX: " + p2VelocityX);
			Debug.Log ("p2VelocityY: " + p2VelocityY);
			Debug.Log ("asdfHoli");
			Thread.Sleep(500);
		}

		mThread.Abort ();
	}

	public bool getCreado(){
		return creado;
	}

	public void setP1Velocity(float x, float y) {
		p1VelocityX = x;
		p1VelocityY = y;
	}

	public float getP2VelocityX(){
		return p2VelocityX;
	}

	public float getP2VelocityY(){
		return p2VelocityY;
	}
}

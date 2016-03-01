using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.IO;

public class socketController1 : MonoBehaviour {
	static bool creado = false;
	Server miServer;
	float p1VelocityX,p1VelocityY,p2VelocityX = 0,p2VelocityY = 0;

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
			ThreadStart ts = new ThreadStart(SayHello);
			mThread = new Thread(ts);
			mThread.Start();
			print("Thread done...");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void SayHello()
	{
				/*try {
						tcp_Listener = new TcpListener (52432);
						tcp_Listener.Start ();
						print ("Server Start");
						while (mRunning) {
								// check if new connections are pending, if not, be nice and sleep 100ms
								if (!tcp_Listener.Pending ()) {
										Thread.Sleep (100);
								} else {
										print ("1");
										TcpClient client = tcp_Listener.AcceptTcpClient ();
										print ("2");
										NetworkStream ns = client.GetStream ();
										print ("3");
										StreamReader reader = new StreamReader (ns);
										print ("4");
										//msg = reader.ReadLine();
										//print(msg);
										reader.Close ();
										client.Close ();
								}
						}
				} catch (ThreadAbortException) {
						print ("exception");
				}*/
		miServer = new Server();
		creado = true;	
	}

	public bool getCreado(){
		return creado;
	}

	public void setP1Velocity(float x, float y){
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

using UnityEngine;
using System.Collections;
using System.Threading;

public class socketController2 : MonoBehaviour {
	static Client tcpCliente;
	Thread mThread;
	bool connected = false;
	string ipObtenida;
	float p1VelocityX = 0, p1VelocityY = 0, p2VelocityX ,p2VelocityY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("pressed1") == 1){
			PlayerPrefs.SetInt("pressed1", 0);
			ipObtenida = PlayerPrefs.GetString("ipObtenido");
			ThreadStart ts = new ThreadStart(threadCliente);
			mThread = new Thread(ts);
			mThread.Start();
			print("Thread done...");

		}
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void threadCliente(){

		tcpCliente = new Client(ipObtenida);
		connected = tcpCliente.getConnected ();
		if (!connected) {
			print ("Fallido");
			mThread.Abort();
		}
		string data, response;
		while (true) {
			data = p2VelocityX + " " + p2VelocityY;
			response = tcpCliente.sendData(data);
			print(response);
		}

	}

	public bool getConnected(){
		return connected;
	}

	public void setP2Velocity(float x, float y){
		p2VelocityX = x;
		p2VelocityY = y;
	}
	
	public float getP1VelocityX(){
		return p1VelocityX;
	}
	
	public float getP1VelocityY(){
		return p1VelocityY;
	}

}

using UnityEngine;
using System.Collections;
using System.Threading;

public class socketController2 : MonoBehaviour {
	static Client tcpCliente;
	Thread mThread;
	bool connected = false;
	string ipObtenida;
	bool running;
	float p1VelocityX = 0, p1VelocityY = 0, bVelocityX = 0, bVelocityY = 0, p2VelocityX, p2VelocityY;
	float p1PositionX = -2, p1PositionY = -2, bPositionX = -2, bPositionY = 0, p2PositionX, p2PositionY;

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
			running = true;
			mThread.Start();
			print("Thread done...");

		}
	}

	void OnApplicationQuit() {
		Debug.Log("Application exit");
		running = false;
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
		string[] separacion, vJugador, vPelota;
		while (running) {
			data = p2VelocityX + "|" + p2VelocityY + "|" + p2PositionX + "|" + p2PositionY;
			response = tcpCliente.sendData(data);
			//Debug.Log (response);
			//Thread.Sleep(200);
			data = tcpCliente.receiveData();
			//Debug.Log (data);
			separacion = data.Split(';');
			vJugador = separacion[0].Split('|');
			vPelota = separacion[1].Split('|');

			p1VelocityX = float.Parse(vJugador[0]);
			p1VelocityY = float.Parse(vJugador[1]);
			p1PositionX = float.Parse(vJugador[2]);
			p1PositionY = float.Parse(vJugador[3]);

			bVelocityX = float.Parse(vPelota[0]);
			bVelocityY = float.Parse(vPelota[1]);
			bPositionX = float.Parse(vPelota[2]);
			bPositionY = float.Parse(vPelota[3]);
		}

	}

	public bool getConnected(){
		return connected;
	}

	public void setP2Velocity(float x, float y){
		p2VelocityX = x;
		p2VelocityY = y;
	}

	public void setP2Position(float x, float y) {
		p2PositionX = x;
		p2PositionY = y;
	}
	
	public float getP1VelocityX(){
		return p1VelocityX;
	}
	
	public float getP1VelocityY(){
		return p1VelocityY;
	}

	public float getP1PositionX(){
		return p1PositionX;
	}
	
	public float getP1PositionY(){
		return p1PositionY;
	}



	public float getBVelocityX(){
		return bVelocityX;
	}
	
	public float getBVelocityY(){
		return bVelocityY;
	}

	public float getBPositionX(){
		return bPositionX;
	}
	
	public float getBPositionY(){
		return bPositionY;
	}
}

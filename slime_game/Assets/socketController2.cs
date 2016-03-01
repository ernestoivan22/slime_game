using UnityEngine;
using System.Collections;
using System.Threading;

public class socketController2 : MonoBehaviour {
	Client tcpclnt;
	Thread mThread;
	bool connected = false;
	string ipObtenida;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("pressed1")==1){
			PlayerPrefs.SetInt("pressed1",0);
			ipObtenida=PlayerPrefs.GetString("ipObtenido");
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

			tcpclnt = new Client(ipObtenida);
		if (!tcpclnt.getConnected ()) {
			print ("Fallido");
			mThread.Abort();

		}

	}

	public bool getConnected(){
		return connected;
	}

}

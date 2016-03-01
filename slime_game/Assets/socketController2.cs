using UnityEngine;
using System.Collections;

public class socketController2 : MonoBehaviour {
	Client tcpclnt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("pressed1")==1){
			tcpclnt = new Client(PlayerPrefs.GetString("ipObtenido"));
			PlayerPrefs.SetInt("pressed1",0);
			if(tcpclnt.getConnected()){
				Application.LoadLevel(1);
			}

		}
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

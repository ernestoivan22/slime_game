using UnityEngine;
using System.Collections;

public class socketController1 : MonoBehaviour {
	static bool creado = false;
	Server miServer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (creado == false) {
			miServer = new Server();
			Application.LoadLevel(1);
			creado = true;		
		}
	}

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}

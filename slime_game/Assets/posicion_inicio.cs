﻿using UnityEngine;
using System.Collections;

public class posicion_inicio : MonoBehaviour {
	public gameManager gManager;
	float posX1 = (float)-2.413441;
	float posY1 = (float)-0.3412947;
	float posX2 = (float)2.213441;
	float posY2 = (float)0.3412947;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		if (gManager.getPlayer1Scored ()) {
			Vector3 temp = new Vector3(posX2,posY2,0);
			transform.position = temp;
		}
		else{
			Vector3 temp = new Vector3(posX1,posY1,0);
			transform.position = temp;
		}
	}
}
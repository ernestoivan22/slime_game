using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	static int p1Score = 0;
	static int p2Score = 0;
	static bool p1Scored = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddScore(int player){
		if (player == 0) {
			p1Score++;	
			print (p1Score);
			Application.LoadLevel(1);
			p1Scored = true;
		}
		else{
			p2Score++;
			print (p2Score);
			Application.LoadLevel(1);
			p1Scored = false;
		}

	}
	void OnGUI(){
		GUILayout.BeginArea(new Rect (0, 0, Screen.width, 20),"");  
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(p1Score + " - " + p2Score, GUILayout.Width(30)); 
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//GUI.Label()
	}
}

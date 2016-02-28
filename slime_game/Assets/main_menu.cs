using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {
	public Texture backgroundTexture;
	int esHost;

	void OnGUI(){
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		//botones
		if(GUI.Button(new Rect(Screen.width*0.25f, Screen.height * 0.5f, Screen.width*0.5f, Screen.height*0.1f),"Host Game")){
			esHost = 1;
			PlayerPrefs.SetInt("esHost",esHost);
			Application.LoadLevel("Inicial");

		}
		if(GUI.Button(new Rect(Screen.width*0.25f, Screen.height * 0.7f, Screen.width*0.5f, Screen.height*0.1f),"Join Game")){
			esHost = 0;
			PlayerPrefs.SetInt("esHost",esHost);
		}
	}

}

using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {

	public float Speed = 0f;
	public float MaxJumpTime = 2f;
	public float JumpForce = 3f;
	private float move = 0f;
	private float JumpTime = 0f;
	private bool CanJump;
	private float movex = 0f;
	private float movey = 0f;
	
	void Start () {
		JumpTime  = MaxJumpTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!CanJump)
			JumpTime  -= Time.deltaTime;
		if (JumpTime <= 0)
		{
			CanJump = true;
			JumpTime  = MaxJumpTime;
		}
		if(PlayerPrefs.GetInt("esHost")==0){
			if (Input.GetKey (KeyCode.RightArrow)) {
				movex = 1;	
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				movex = -1;	
			} else {
				movex = 0;
			}
		}
		
	}
	
	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		//rigidbody2D.velocity = new Vector2 (move * Speed, rigidbody2D.velocity.y);
		if (PlayerPrefs.GetInt ("esHost") == 0) {
			if (Input.GetKey (KeyCode.UpArrow)  && CanJump)
			{
				rigidbody2D.AddForce (new Vector2 (0,JumpForce));
				CanJump = false;
				JumpTime  = MaxJumpTime;
			}
		}
		
		rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
}

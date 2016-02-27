using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour {
	public float Speed = 0f;
	public float MaxJumpTime = 2f;
	public float JumpForce;
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
		if (Input.GetKey (KeyCode.D)) {
				movex = 1;	
		} else if (Input.GetKey (KeyCode.A)) {
				movex = -1;	
		} else {
				movex = 0;
		}
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * Speed, rigidbody2D.velocity.y);
		if (Input.GetKey (KeyCode.W)  && CanJump)
		{
			rigidbody2D.AddForce (new Vector2 (rigidbody2D.velocity.x,JumpForce));
			CanJump = false;
			JumpTime  = MaxJumpTime;
		}
		rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
}

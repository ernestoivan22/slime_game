using UnityEngine;
using System.Collections;

public class rebote : MonoBehaviour {
	// Constant speed of the ball
	private float speed = 4f;
	private float maxSpeed = 12f;
	private float vX;
	private float vY;
	
	// Keep track of the direction in which the ball is moving
	private Vector2 velocity;
	
	// used for velocity calculation
	private Vector2 lastPos;
	// Use this for initialization
	void Start () {
		// Random direction
		rigidbody2D.velocity = new Vector2(0,0) * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		// Get pos 2d of the ball.
		Vector3 pos3D = transform.position;
		Vector2 pos2D = new Vector2(pos3D.x, pos3D.y);
		
		// Velocity calculation. Will be used for the bounce
		velocity = pos2D - lastPos;
		vX = rigidbody2D.velocity.x;
		vY = rigidbody2D.velocity.y;
		if (vY > maxSpeed) {
			vY = maxSpeed;
			rigidbody2D.velocity = new Vector2(vX, vY);
		}
		if (vX > maxSpeed) {
			vX = maxSpeed;
			rigidbody2D.velocity = new Vector2(vX, vY);
		}
		lastPos = pos2D;
	}
	
	private void OnCollisionEnter2D(Collision2D col)
	{
		// Normal
		Vector3 N = col.contacts[0].normal;
		//Direction
		Vector3 V = velocity.normalized;
		
		// Reflection
		Vector3 R = Vector3.Reflect(V, N).normalized*2;
		
		// Assign normalized reflection with the constant speed
		vX = R.x;
		vY = R.y;
		if (vX > maxSpeed) {
			vX = maxSpeed;
		}
		if (vY > maxSpeed) {
			vY = maxSpeed;
		}
		rigidbody2D.velocity = new Vector2(vX, vY) * speed;
		//rigidbody2D.AddForce
	}
}

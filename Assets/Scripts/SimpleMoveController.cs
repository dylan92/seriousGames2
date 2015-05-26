using UnityEngine;
using System.Collections;

public class SimpleMoveController : MonoBehaviour {


	public Rigidbody2D rigidbody;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		var moveX = Input.GetAxis ("Horizontal");
		var moveY = Input.GetAxis ("Vertical");
		rigidbody.velocity = new Vector2 (moveX * speed, moveY * speed);
	}
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public enum Orientation {
		Left,
		Right
	}

	public Orientation orientation;

	public float movementSpeedMin = 0.1f;
	public float movementSpeedMax = 0.3f;

	private float movementSpeed;
	
	// Use this for initialization
	void Start () {
		movementSpeed = Random.Range (movementSpeedMin, movementSpeedMax);
		if (orientation == Orientation.Right) {
			this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (orientation == Orientation.Left) {
			this.transform.position += new Vector3 (-movementSpeed, 0f, 0f);
		} else if (orientation == Orientation.Right) {
			this.transform.position += new Vector3 (movementSpeed, 0f, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GameManager.Instance.ResetLevel ();
		} else if (other.gameObject.tag == "EnemyWall") {
			Destroy(this.gameObject);
		}
	}
}

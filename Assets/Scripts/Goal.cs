using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public string nextSceneToLoad;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel(nextSceneToLoad);
		}
	}
}

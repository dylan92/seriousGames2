using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public Spawn[] spawns;
	public int initialSpawns = 5;
	public int spawnsPerMinute = 15;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this.gameObject);
		}

		Application.targetFrameRate = 60;
	}

	void Start() {

		if (spawns.Length > 0) {
			for (int i = 0; i < initialSpawns; i++) {
				Spawn ();
			}
			if (spawnsPerMinute > 0) {
				StartCoroutine (SpawnOverTime ());
			}
		}
	}

	IEnumerator SpawnOverTime() {
		while (true) {
			yield return new WaitForSeconds(60f / (float)spawnsPerMinute);
			Spawn();
		}
	}

	void Spawn() {
		var s = spawns [Random.Range(0, spawns.Length)];
		float x =	Random.Range(s.minXPosition, s.maxXPosition);
		float y = Random.Range(s.minYPosition, s.maxYPosition);

		Instantiate (s.spawnObject, new Vector3(x, y, 0f), Quaternion.identity);
	}

	public void ResetLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}
}

[System.Serializable]
public class Spawn {
	public GameObject spawnObject;
	public float minXPosition;
	public float maxXPosition;
	public float minYPosition;
	public float maxYPosition;
}

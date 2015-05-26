using UnityEngine;
using System.Collections;

public class WaterCharacter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "WaterDrop") {
			var size  = other.gameObject.GetComponent<WaterDrop>().size;
			this.transform.localScale = new Vector3(this.transform.localScale.x + size, this.transform.localScale.y + size, this.transform.localScale.z + size);
			Destroy(other.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ZombieKillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			Destroy(other.gameObject);
			GameObject.FindGameObjectWithTag("ResetText").GetComponent<Text>().enabled = true;
		}
	}
}

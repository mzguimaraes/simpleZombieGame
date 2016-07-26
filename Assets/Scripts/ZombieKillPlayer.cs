using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class ZombieKillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Kill player");
		if (other.tag == "Player"){
			SceneManager.LoadScene(1);
		}
	}
}

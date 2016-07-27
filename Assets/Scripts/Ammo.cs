using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int ammoCountMax = 10;

	private int ammoCount;

	void Start() {
		ammoCount = Random.Range(1, ammoCountMax);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerMoveShoot>().gainAmmo(ammoCount);
			Destroy(gameObject);
		}
	}
}

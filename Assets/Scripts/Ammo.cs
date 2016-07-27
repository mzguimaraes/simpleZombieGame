using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int ammoCountMin = 4;
	public int ammoCountMax = 8;

	private int ammoCount;

	void Start() {
		ammoCount = Random.Range(ammoCountMin, ammoCountMax);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerMoveShoot>().gainAmmo(ammoCount);
			Destroy(gameObject);
		}
	}
}

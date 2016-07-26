using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

	public GameObject zombie;
	public float spawnTimer = 3f;
	
	// Update is called once per frame
	void Start () {
		InvokeRepeating("spawnZombie", 0, spawnTimer);
	}

	void spawnZombie() {
		Instantiate(zombie, transform.position - new Vector3 (0f, 1f, 0f), Quaternion.identity);
	}
}

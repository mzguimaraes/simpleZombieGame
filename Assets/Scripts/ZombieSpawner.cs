using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

	public GameObject zombie;
	public float startSpawnTimer = 5f;
	//public float spawnDelay = 0f;
	public float spawnDecayScalar = 50f;
	public float spawnRateFloor = 0.75f;
	public float spawnChance = 0.6f;

	private float spawnCooldown = 0f;
	
	// Update is called once per frame
	void Start () {
		//InvokeRepeating("spawnZombie", spawnDelay, startSpawnTimer);
		//Invoke("spawnZombie", findSpawnCooldown());
	}

	void Update () {
		spawnCooldown -= Time.deltaTime;
		if (spawnCooldown <= 0f) {
			spawnZombie();
			spawnCooldown = findSpawnCooldown();
		}

	}

	void spawnZombie() {
		if (Random.value <= spawnChance) {
			Instantiate(zombie,
						transform.position + (Vector3.down * transform.rotation.eulerAngles.magnitude),
						Quaternion.identity);
		}
	}

	private float findSpawnCooldown() {

		//computes spawn cooldown based on exponential decay (function of game time)
		//f(x) = startSpawnTimer * exp(gameTime / spawnDecayScalar)
		float returnCandidate = startSpawnTimer * 
								Mathf.Exp( (-1f) * (Time.timeSinceLevelLoad / spawnDecayScalar) );
		if (returnCandidate < spawnRateFloor) {
			return spawnRateFloor;
		}
		else return returnCandidate;
	}
}

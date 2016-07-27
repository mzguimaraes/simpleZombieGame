using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

	public GameObject zombie;
	public float startSpawnTimer = 5f;
	public float spawnDecayScalar = 30f;
	public float spawnRateFloor = 0.75f;
	public float spawnChance = 0.6f;
	public float maxSpawnDelay = 5f;

	private float spawnCooldown = 0f;
	private float spawnDelay;

	void Start () {
		spawnDelay = Random.value * maxSpawnDelay;
	}

	void Update () {
		spawnCooldown -= Time.deltaTime;
		if (spawnCooldown <= 0f) {
			if (Random.value <= spawnChance) {
				Invoke("spawnZombie", spawnDelay);
				spawnCooldown = findSpawnCooldown();
			}
		}

	}

	void spawnZombie() {
		Instantiate(zombie,
					transform.position + (Vector3.down * transform.rotation.eulerAngles.magnitude),
					Quaternion.identity);
	
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

using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float speed = 50;
	public int health = 1;
	public GameObject ammo;
	public float ammoDropRate = 0.3f;

	private GameObject player;
	private Vector3 moveVector = Vector3.zero;
	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		if (ammoDropRate > 1f) {
			ammoDropRate = 1f;
		}
	}

	void FixedUpdate() {
		if (player != null) {
			Vector3 toPlayer = player.transform.position - transform.position;
			toPlayer.z = 0; //just in case
			moveVector = toPlayer.normalized * speed * Time.fixedDeltaTime;
			rb2d.velocity = moveVector;
		}
		else {
			rb2d.velocity = Vector2.zero;
		}
	}

	public void TakeDamage() {
		health--;
		if (health <= 0) {
			GameObject.FindObjectOfType<PointSystem>().incrementZombiesToAdd();

			if (Random.value <= ammoDropRate) {
				Instantiate(ammo,
							transform.position,
							Quaternion.identity);
			}

			Destroy(gameObject);
		}
	}
}

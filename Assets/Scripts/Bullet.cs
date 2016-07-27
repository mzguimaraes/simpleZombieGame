using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float velocity = 10f;
	public float timeForExistence = 5f;

	private Vector3 forward;  //direction to move in
	private Rigidbody2D rb2d;
	private float timeExisted = 0;

	// Use this for initialization
	void Start () {
		forward = GameObject.FindGameObjectWithTag("Player").transform.up;
		forward.z = 0;
		if (forward.magnitude > 1f)
			forward.Normalize();
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = forward * velocity;
	}

	void Update() {
		timeExisted += Time.deltaTime;
		if (timeExisted >= timeForExistence) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Zombie") {
			other.GetComponent<Zombie>().TakeDamage();
		}
		else if (other.tag == "Player" || other.tag == "Ammo") {
			return;
		}

		Destroy(gameObject);
	}
}

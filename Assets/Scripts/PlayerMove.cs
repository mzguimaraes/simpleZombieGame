using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 50f;

	private Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();

	}

	void Update () {
		//Get rotation
		Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		lookDir.z = 0f;
		transform.up = lookDir;
	}
	
	void FixedUpdate () {
		rb2d.velocity = Vector3.zero;

		//Get movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical  = Input.GetAxis("Vertical");
		Vector3 move = new Vector3(horizontal, vertical, 0f);
		if (move.magnitude > 1f) {
			move.Normalize();
		}

		move *= speed * Time.deltaTime;

		rb2d.velocity = move;


	}
}

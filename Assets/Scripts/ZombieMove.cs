using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour {

	public float speed = 50;

	private GameObject player;
	private Vector3 moveVector = Vector3.zero;
	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

//	void Update () {
//		Debug.Log("Velocity difference: " + 
//			(player.gameObject.GetComponent<Rigidbody2D>().velocity - rb2d.velocity));
//	}

	void FixedUpdate() {
		Vector3 toPlayer = player.transform.position - transform.position;
		toPlayer.z = 0; //just in case
		moveVector = toPlayer * speed * Time.fixedDeltaTime;
		rb2d.velocity = moveVector;
	}
}

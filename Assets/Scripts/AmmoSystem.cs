using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour {

	public Text text;

	private PlayerMoveShoot player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveShoot>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Ammo: " + player.AmmoCount;
	}
}

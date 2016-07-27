using UnityEngine;
using System.Collections;

public class Debug_playerPos : MonoBehaviour {

	public Transform player;

	// Update is called once per frame
	void Update () {
		Debug.Log(player.transform.position);
	}
}

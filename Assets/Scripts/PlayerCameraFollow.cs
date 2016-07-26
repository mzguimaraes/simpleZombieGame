using UnityEngine;
using System.Collections;

public class PlayerCameraFollow : MonoBehaviour {

	public Vector3 offset = new Vector3(0f, 0f, 0f);

	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = transform.position + offset;
	}
}

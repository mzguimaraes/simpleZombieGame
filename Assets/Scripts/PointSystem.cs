using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

	public Text text;

	private int score = 0;
	public int Score {
		get {
			return score;
		}
	}

	private int zombiesToAdd = 0;

	void Start () {
		text.text = "Zombies killed: " + score;
	}

	// Update is called once per frame
	void Update () {
		if (zombiesToAdd != 0) {
			score += zombiesToAdd;
			zombiesToAdd = 0;
			text.text = "Zombies killed: " + score;
		}
	}

	public void incrementZombiesToAdd() {
		zombiesToAdd++;
	}
}

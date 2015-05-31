using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int scorePlayerOne = 0;
	private int scorePlayerTwo = 0;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
	
	}

	public void addScore(int playerNum){
		if (playerNum == 1) {
			scorePlayerOne++;
		} else {
			scorePlayerTwo++;
		}
	}
}

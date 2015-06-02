using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public AudioClip audioStart;

	private int scorePlayerOne = 0;
	private int scorePlayerTwo = 0;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (audioStart, Vector3.zero);
	}

	void FixedUpdate () {
	
	}

	public void addScore(int playerNum){
		if (playerNum == 1) {
			scorePlayerOne++;
			if(scorePlayerOne >= 9){
				Application.LoadLevel("WinP1");
			}
		} else {
			scorePlayerTwo++;
			if(scorePlayerTwo >= 9){
				Application.LoadLevel("WinP2");
			}
		}
	}
}

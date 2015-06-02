using UnityEngine;
using System.Collections;

public class VictoryScreen : MonoBehaviour {

	public AudioClip audioWin;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (audioWin, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3f && (Input.GetButton ("Player1Action") || Input.GetButton ("Player2Action") )) {

			Application.LoadLevel("room");
		}
	}
}

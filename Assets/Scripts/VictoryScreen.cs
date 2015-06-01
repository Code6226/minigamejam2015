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
		if (Time.time > 3f && (Input.GetButtonDown ("Submit") || Input.GetButton ("Fire1") || Input.GetKey (KeyCode.LeftControl))) {

			Application.LoadLevel("room");
		}
	}
}

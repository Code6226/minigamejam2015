using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public AudioClip audioStart;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit") || Input.GetButton ("Fire1") || Input.GetKey (KeyCode.LeftControl)) {
			//AudioSource.PlayClipAtPoint (audioStart, Vector3.zero);

			Application.LoadLevel("room");
		}
	}
}

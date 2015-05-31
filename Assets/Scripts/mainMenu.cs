using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit") || Input.GetKey (KeyCode.LeftControl)) {
			Application.LoadLevel("room");
		}
	}
}

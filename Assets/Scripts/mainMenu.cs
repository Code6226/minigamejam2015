using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public AudioClip audioStart;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Player1Action") || Input.GetButton ("Player2Action")){
			//AudioSource.PlayClipAtPoint (audioStart, Vector3.zero);

			Application.LoadLevel("room");
		}
	}
}

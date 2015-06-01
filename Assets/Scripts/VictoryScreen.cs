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
	
	}
}

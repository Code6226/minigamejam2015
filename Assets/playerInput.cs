using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {
	private Rigidbody2D body;
	public float acceleration;
	public float maxSpeed;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// All Physics go here
	void FixedUpdate () {
		Vector2 movement = new Vector2(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		body.AddForce (movement);
	}
}

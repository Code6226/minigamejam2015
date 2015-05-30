using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {
	private Rigidbody2D body;
	public float acceleration;
	public float maxSpeed;
	public int playerNum;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// All Physics go here
	void FixedUpdate () {
		Vector2 movement = new Vector2(Input.GetAxis ("Horizontal"+playerNum), Input.GetAxis ("Vertical"+playerNum));
		movement.Scale (new Vector2 (15, 15));
		body.AddForce (movement);
	}
}

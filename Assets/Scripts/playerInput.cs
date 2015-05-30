using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {
	private Rigidbody2D body;
	public int playerNum;

	private float deadZone = 0.01f;
	
	public Animator animator;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	// All Physics go here
	void FixedUpdate () {
		float inputX = Input.GetAxis ("Horizontal" + playerNum);
		float inputY = Input.GetAxis ("Vertical" + playerNum);
		Vector2 movement = new Vector2(inputX, inputY);
		movement.Scale (new Vector2 (15, 15));
		body.AddForce (movement);



		// Set the z rotation of that player to point at the way he is inputting
		if (Mathf.Abs (inputX) > deadZone || Mathf.Abs (inputY) > deadZone) {
			float angle = Mathf.Atan2 (inputY, inputX) * Mathf.Rad2Deg + 90f;

			transform.localEulerAngles = new Vector3 (0, 0, angle);
		}

		animator.speed = body.velocity.magnitude * 0.25f;


	}
}

using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {
	private Rigidbody2D body;
//	private CircleCollider2D colliderFood;
	private FoodCarrier foodCarrier;

	public int playerNum;

	private float deadZone = 0.01f;
	
	public Animator animator;

	private float inputX = 0f;
	private float inputY = 0f;
	private bool inputGrab = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
//		colliderFood = GetComponent<CircleCollider2D> ();
		animator = GetComponent<Animator> ();
		foodCarrier = GetComponent<FoodCarrier> ();
	}
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis ("Horizontal" + playerNum);
		inputY = Input.GetAxis ("Vertical" + playerNum);

		if ((playerNum == 1 && Input.GetKey ("w")) || (playerNum == 2 && Input.GetKey ("up"))) {
			inputY = 1f;
		} else if ((playerNum == 1 && Input.GetKey ("s")) || (playerNum == 2 && Input.GetKey ("down"))) {
			inputY = -1f;
		}

		if ((playerNum == 1 && Input.GetKey ("a")) || (playerNum == 2 && Input.GetKey ("left"))) {
			inputX = -1f;
		} else if ((playerNum == 1 && Input.GetKey ("d")) || (playerNum == 2 && Input.GetKey ("right"))) {
			inputX = 1f;
		}

		//		bool inputGrab = Input.GetButton ("Fire1");
		inputGrab = ((playerNum == 1 && Input.GetKey (KeyCode.LeftControl)) || (playerNum == 2 && Input.GetKey (KeyCode.RightShift)));

	}
	
	// All Physics go here
	void FixedUpdate () {
		Vector2 movement = new Vector2(inputX, inputY);
		movement.Scale (new Vector2 (15, 15));
		body.AddForce (movement);



		// Set the z rotation of that player to point at the way he is inputting
		if (Mathf.Abs (inputX) > deadZone || Mathf.Abs (inputY) > deadZone) {
			float angle = Mathf.Atan2 (inputY, inputX) * Mathf.Rad2Deg + 90f;

			transform.localEulerAngles = new Vector3 (0, 0, angle);
		}

		animator.speed = body.velocity.magnitude * 0.25f;

		if (inputGrab) {
			foodCarrier.tryPickup();
			//transform.localEulerAngles = new Vector3 (0, 0, 45);
		} else {
			foodCarrier.tryDrop();
		}
	}
}

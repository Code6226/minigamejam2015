using UnityEngine;
using System.Collections;

public class FoodCarrier : MonoBehaviour {

	public AudioClip audioGrab;
	public AudioClip audioGrabKitty;

//	private FoodSpawn foodSpawn;
	private Animator animator;
	private Rigidbody2D body;

	private GameObject lastTouchedFood;
	private GameObject carryingFood;

	private bool isCarrying = false;

	// Use this for initialization
	void Start () {
//		foodSpawn = GameObject.FindObjectOfType<FoodSpawn> ();
		animator = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		//if (other.gameObject.tCompareTag ("Pick Up"))
		if (other.gameObject.CompareTag ("Pickup")) {
			lastTouchedFood = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		//if (other.gameObject.tCompareTag ("Pick Up"))
		if (other.gameObject.CompareTag ("Pickup")) {
			if (lastTouchedFood == other.gameObject) {
				lastTouchedFood = null;
			}
		}
	}

	public void tryPickup() {
		if (isCarrying || !lastTouchedFood) {
			return;
		}

		carryingFood = lastTouchedFood;
		lastTouchedFood = null;

		if (animator) {
			Carryable carryable = carryingFood.GetComponent<Carryable>();
			if(!carryable){
				Debug.LogError("Tried to pickup something not Carryable");
			}else{
				animator.SetInteger("Carrying", carryable.getType());
				if(carryable.getIsKitty()){
				   AudioSource.PlayClipAtPoint (audioGrabKitty, Vector3.zero);
					body.mass += carryingFood.GetComponent<Rigidbody2D>().mass;
				}
			}
		}
		AudioSource.PlayClipAtPoint (audioGrab, Vector3.zero);

		carryingFood.SetActive (false);
//		Destroy (lastTouchedFood);
		isCarrying = true;
	}

	public void tryDrop() {
		if (!isCarrying) {
			return;
		}
		if (animator) {
			animator.SetInteger("Carrying", 0);
//			animator.speed = 100; // hack to make the transition happen faster ?
//			animator.Update(10f);
		}
		body.mass = 1; // reset after dropping kitties

		// relocate picked up object right in from of myself
		Vector2 dirVec = body.velocity.normalized * 1.3f; // set length to x unity units
		carryingFood.transform.position = new Vector2(transform.position.x + dirVec.x, transform.position.y + dirVec.y);
		carryingFood.SetActive (true);

		carryingFood.GetComponent<Rigidbody2D> ().velocity = new Vector2 (body.velocity.x, body.velocity.y);

		carryingFood = null;
		isCarrying = false;
	}
}

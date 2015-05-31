using UnityEngine;
using System.Collections;

public class FoodCarrier : MonoBehaviour {
	
//	private FoodSpawn foodSpawn;

	private GameObject lastTouchedFood;
	private GameObject carryingFood;

	private bool isCarrying = false;

	// Use this for initialization
	void Start () {
//		foodSpawn = GameObject.FindObjectOfType<FoodSpawn> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		//if (other.gameObject.tCompareTag ("Pick Up"))
		lastTouchedFood = other.gameObject;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		//if (other.gameObject.tCompareTag ("Pick Up"))
		if (lastTouchedFood == other.gameObject) {
			lastTouchedFood = null;
		}
	}

	public void tryPickup() {
		if (isCarrying || !lastTouchedFood) {
			return;
		}
		carryingFood = lastTouchedFood;
		lastTouchedFood = null;

		carryingFood.SetActive (false);
//		Destroy (lastTouchedFood);
		isCarrying = true;
	}

	public void tryDrop() {
		if (!isCarrying) {
			return;
		}
		carryingFood.transform.position = new Vector2(transform.position.x, transform.position.y);

		carryingFood.SetActive (true);
		carryingFood = null;
		isCarrying = false;
	}
}

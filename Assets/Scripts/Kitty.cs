using UnityEngine;
using System.Collections;

public class Kitty : MonoBehaviour {

	public int playerNum;

	private FoodMeter foodMeter;
	private int foodCount = 0;

	// Use this for initialization
	void Start () {
		foodMeter = GetComponentInChildren<FoodMeter> ();
//		foodMeter.setCount (3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			if (foodCount < 3) {
				Destroy(other.gameObject);
				foodCount++;
				foodMeter.setCount(foodCount);
			}
		}
	}
}

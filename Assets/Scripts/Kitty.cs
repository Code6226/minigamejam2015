using UnityEngine;
using System.Collections;

public class Kitty : MonoBehaviour {

	public int playerNum;

	private FoodMeter foodMeter;
	private int foodCount = 0;

	private GameManager gameManager; 

	// Use this for initialization
	void Start () {
		foodMeter = GetComponentInChildren<FoodMeter> ();
		gameManager = GameObject.FindObjectOfType<GameManager> ();
//		foodMeter.setCount (3);
	}
	
	// Update is called once per frame
	void Update () {
		// animation time is forgotten after dis-re-enabling - so far picking up and dropping the kitty off elsewhere
		foodMeter.setCount(foodCount);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			if (foodCount < 3) {
				Destroy(other.gameObject);
				foodCount++;
				foodMeter.setCount(foodCount);

				gameManager.addScore(playerNum);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Kitty : MonoBehaviour {

	public int playerNum;
	public AudioClip audioEat;

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

	// eat food
	void OnTriggerEnter2D(Collider2D other) {
		if (foodCount < 3 && other.gameObject.CompareTag ("Pickup")) {

			Carryable carryable = other.gameObject.GetComponent<Carryable>();
			if(!carryable){
				Debug.LogError("Tried to pickup something not Carryable");
			}else{
				if (carryable.getType() == 1) { // kittens shall not eat each other
					AudioSource.PlayClipAtPoint (audioEat, Vector3.zero);
					Destroy(other.gameObject);
					foodCount++;
					foodMeter.setCount(foodCount);
					// More massive kitty!
					GetComponent<Rigidbody2D>().mass = foodCount * 2f;

					gameManager.addScore(playerNum);
				}
			}
		}
	}
}

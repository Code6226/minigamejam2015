using UnityEngine;
using System.Collections;

public class FoodMeter : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCount(int count){
		animator.Play ("FoodMeter", 0, 0.3f * count); // seems to range from 0 to 1 for all frames
	}
}

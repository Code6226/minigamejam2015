using UnityEngine;
using System.Collections;

public class Carryable : MonoBehaviour {

	public int carryType = 1;
	// 1 Chicken, 2 P1 Kitty, 3 P2 Kitty

	// Use this for initialization
	void Start () {
	
	}

	public int getType(){
		return carryType;
	}
}

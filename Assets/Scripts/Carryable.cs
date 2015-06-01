using UnityEngine;
using System.Collections;

public class Carryable : MonoBehaviour {

	public int carryType = 1;
	public int isFood = 0; // why doesn't this show?

	// 1 Chicken, 2 P1 Kitty, 3 P2 Kitty

	// Use this for initialization
	void Start () {
	
	}

	public int getType(){
		return carryType;
	}

	public bool getIsFood(){
		return isFood == 1;
	}

	public bool getIsKitty(){
		return carryType == 2 || carryType == 3;
	}
}

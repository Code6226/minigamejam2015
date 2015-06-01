using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodSpawn : MonoBehaviour {

	public float frequency;
	public float posMaxX;
	public float posMinX;
	public float posMaxY;
	public float posMinY;

	public GameObject[] foodPrefabs;

	private float nextSpawn;
	private System.DateTime epochStart;

	private float someTime;

//	private List<GameObject> foods;

	// Use this for initialization
	void Start () { 
		setNextSpawn ();

//		foods = new List<GameObject>();
	}

	void setNextSpawn(){
		nextSpawn = Time.time + frequency;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(spawn);

		if (Time.time >= nextSpawn) {
			var pos = new Vector2 (Random.Range (posMinX, posMaxX), Random.Range (posMinY, posMaxY));
			GameObject food = (GameObject)Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], pos, transform.rotation);
//			foods.Add(food);

			setNextSpawn ();
		}
	}
}

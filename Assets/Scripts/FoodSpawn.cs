using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodSpawn : MonoBehaviour {

	public int frequency;
	public float posMaxX;
	public float posMinX;
	public float posMaxY;
	public float posMinY;

	private int lastSpawn;
	private System.DateTime epochStart;

//	private List<GameObject> foods;

	// Use this for initialization
	void Start () { 
		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		
		lastSpawn = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds;

//		foods = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds;

		int spawn = cur_time - lastSpawn;
//		Debug.Log(spawn);

		if (spawn >= frequency) {
			var pos = new Vector2 (Random.Range (posMinX, posMaxX), Random.Range (posMinY, posMaxY));
			GameObject food = (GameObject)Instantiate (Resources.Load ("FoodA"), pos, transform.rotation);
//			foods.Add(food);

			lastSpawn = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds;
		}
	}
}

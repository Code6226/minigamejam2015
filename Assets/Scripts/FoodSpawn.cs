using UnityEngine;
using System.Collections;

public class FoodSpawn : MonoBehaviour {

	public int frequency;
	public float posMaxX;
	public float posMinX;
	public float posMaxY;
	public float posMinY;

	private int lastSpawn;
	private System.DateTime epochStart;

	// Use this for initialization
	void Start () { 
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		
		lastSpawn = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds; 
	}
	
	// Update is called once per frame
	void Update () {

		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds;

		int spawn = cur_time - lastSpawn;
		Debug.Log(spawn);

		if (spawn >= frequency) {
			var pos = new Vector2 (Random.Range (posMinX, posMaxX), Random.Range (posMinY, posMaxY));
			GameObject prefab = (GameObject)Instantiate (Resources.Load ("FoodA"), pos, transform.rotation);

			lastSpawn = (int)(System.DateTime.UtcNow - epochStart).TotalMilliseconds;
		}


	}
}

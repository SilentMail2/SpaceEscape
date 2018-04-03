using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public float timeMin;
	public float timeMax;

	public GameObject obstacle;

	public GameObject[] Obstacles;

	public GameObject spawnpoint;
	public int index;


	public float spawnCount;
	public float spawnCounted;

	private float obstaclelength;
	// Use this for initialization
	void Start () {

		/*Vector3 position = Obstacles [Random.Range (0, Obstacles.Count)].position;
		obstacle = Instantiate (spawnpoint, position, Quaternion.identity);
*/
		index = Random.Range (0, Obstacles.Length);
		obstacle = Obstacles [index];

	}
	
	// Update is called once per frame
	void Update () {
		if (spawnCounted <= 0) {
			
			Instantiate (obstacle, new Vector3 (spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
			
			index = Random.Range (0, Obstacles.Length);
			obstacle = Obstacles [index];

			spawnCount = Random.Range (timeMin, timeMax);
			spawnCounted = Time.deltaTime + spawnCount;
		}
		spawnCounted --;

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterControl : MonoBehaviour {
	public float distanceToPlayer;
	public float MaxdistanceToPlayer;
	public float moveDir;
	public float moveSpeed;
	public float boost;
	public bool BoostMode = false;
	//public float boosttime;
	public Slider MonsterDistance;
	public GameObject Player;
	public GameObject Monster;
    public GameObject MonsterPoint;
    private Player_Controller playerValues;
	Rigidbody MonsterRB;
	// Use this for initialization
	void Start () {
		MonsterRB = GetComponent <Rigidbody> ();
		distanceToPlayer = (Vector3.Distance (MonsterPoint.transform.position, transform.position)-7);
		MaxdistanceToPlayer = distanceToPlayer;
		playerValues = Player.GetComponent<Player_Controller> ();
		BoostMode = playerValues.boostMode;
	}
	// Update is called once per frame
	void Update () {
		BoostMode = playerValues.boostMode;
		distanceToPlayer = (Vector3.Distance (Player.transform.position, transform.position)-20);
		MonsterDistance.value = distanceToPlayer/MaxdistanceToPlayer;
		if (!BoostMode) {
			MonsterRB.velocity = new Vector3 (-moveDir * moveSpeed,0, 0);
		}
		if (BoostMode) {
			MonsterRB.velocity = new Vector3 (-moveDir * moveSpeed, 0, 0);
			/*boosttime = boosttime+Time.deltaTime - 0.1f;
			if (boosttime <= 0) {
				BoostMode = false;
				boosttime = 20;
			}*/
		}
		if (distanceToPlayer <= 0) {
            playerValues.DieScript();
			Debug.Log ("GameOver");
		}
	}
}

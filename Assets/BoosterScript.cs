using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour {
	public GameObject Player;
	private Player_Controller playerValues;

	public bool boostMode;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerValues = Player.GetComponent<Player_Controller> ();
		boostMode = playerValues.boostMode;
	}
	
	// Update is called once per frame
	void Update () {
		boostMode = playerValues.boostMode;
	}
}

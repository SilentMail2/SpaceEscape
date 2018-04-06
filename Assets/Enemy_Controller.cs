using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_Controller : MonoBehaviour {
	public float Movement_speed = 10;
	public int healthPoints = 100;
	public bool isDestroyable = true;
	public GameObject Player;
	private Player_Controller playerValues;
	public bool boostMode;
	public float boostTimer = 20f;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerValues = Player.GetComponent<Player_Controller> ();
		boostMode = playerValues.boostMode;
	}
	// Update is called once per frame
	void Update () {
		boostMode = playerValues.boostMode;
		if (!boostMode) {
			transform.Translate (Movement_speed*Time.deltaTime, 0, 0);
			if (healthPoints <= 0) {
				Destroy (this.gameObject);
			}
		}
		if (boostMode)
		{
			transform.Translate (Movement_speed*Time.deltaTime*2, 0, 0);
		}
	}
	private void OnCollisionEnter (Collision other)
	{
		if (isDestroyable == true) {
			if (other.gameObject.tag == "Lazer") {
				Debug.Log ("Collided OBJECt");
				healthPoints = healthPoints - 100;
			}	
		}
		if (other.gameObject.tag == "Player") 
		{
			Destroy (this.gameObject);
		}
		if (other.gameObject.tag == "Monster") 
		{
			Destroy (this.gameObject);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour {
	public bool BoostMode;
	public float boostTimer = 20f;
	public float Movement_speed = 20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!BoostMode) {
			var z = Time.deltaTime * Movement_speed;
			transform.Translate (0, z, 0);
		}
		if (BoostMode) {
			boostTimer = boostTimer+Time.deltaTime - 0.1f;
			var z = Time.deltaTime * Movement_speed*2f;
			transform.Translate (0, z, 0);
			if (boostTimer <= 0) {
				BoostMode = false;
				boostTimer = 20;
			}
		}
	}
	public void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			BoostMode = true;
		}
		if (other.tag == "Monster") {
			Destroy (this.gameObject);
		}
	}
}

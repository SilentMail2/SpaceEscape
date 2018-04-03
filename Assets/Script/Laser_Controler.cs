using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controler : MonoBehaviour {
	public float laser_speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var z = Time.deltaTime * laser_speed;
		transform.Translate (z, 0, 0);
	}

	private void OnCollisionEnter (Collision other)
	{
		
			Debug.Log ("Collided");
		Destroy (this.gameObject);
	}
}

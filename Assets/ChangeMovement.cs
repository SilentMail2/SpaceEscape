using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class ChangeMovement : MonoBehaviour {
	public float movementSpeed;
	public GameObject PlayerObject;
	// Use this for initialization
	void Start () {
		PlayerObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (movementSpeed*Time.deltaTime, 0, 0);
	}
	public void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == ("Player")) {
			Destroy (this.gameObject);
		}
		if (other.gameObject.tag == ("Monster")) {
			Destroy (this.gameObject);
		}
	}
}

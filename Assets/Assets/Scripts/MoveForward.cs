using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
	Rigidbody2D rig;
	public float moveSpeed = 20f;
	// Use this for initialization
	void Start () {
		rig = this.transform.GetComponent<Rigidbody2D>();
		rig.AddForce (transform.up * 2 * (moveSpeed), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		//rig.AddForce (transform.up * 2 * (moveSpeed));
	}
}

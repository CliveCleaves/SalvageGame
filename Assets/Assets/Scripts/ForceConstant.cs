using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceConstant : MonoBehaviour {
	Rigidbody2D rig;
	public float moveSpeed = 20f;

	// Use this for initialization
	void Start () {
		rig = this.transform.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		rig.AddForce (transform.up * 2 * (moveSpeed), ForceMode2D.Force);
	}
}

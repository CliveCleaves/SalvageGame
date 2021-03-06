﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rig;
	ParticleSystem part;

	float rotSpeed = 100f;
	float moveSpeed = 20f;

	void Start () {
		rig = this.transform.GetComponent<Rigidbody2D>();
		part = this.transform.GetComponentInChildren<ParticleSystem> ();
	}

	void Update () {
		// This may be able to be removed with the mobile input below.
//		float v = Input.GetAxis ("Vertical");
//		float h = Input.GetAxis ("Horizontal");
//		if (v != 0 || h != 0) {
//			if (!part.isPlaying) part.Play();
//			float myAngle = Mathf.Atan2 (-Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * Mathf.Rad2Deg;
//			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, myAngle, rotSpeed * Time.deltaTime);
//			transform.eulerAngles = new Vector3 (0, 0, angle);
//
//			rig.AddForce (transform.up * 2 * (moveSpeed));
//
//		} else {
//			if (part.isPlaying) part.Stop();
//		}
		float vm = CrossPlatformInputManager.GetAxis ("Vertical");
		float hm = CrossPlatformInputManager.GetAxis ("Horizontal");

		if (vm != 0 || hm != 0) {
			if (!part.isPlaying) part.Play();
			float myAngle = Mathf.Atan2 (-CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical")) * Mathf.Rad2Deg;
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, myAngle, rotSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, angle);

			rig.AddForce (transform.up * 2 * (moveSpeed));

		} else {
			if (part.isPlaying) part.Stop();
		}
	}
}

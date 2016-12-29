using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {
	Transform player;
	float maxSpeed = 5f;
	Rigidbody2D rig;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			// Find the players ship.
			GameObject go = GameObject.Find("PlayerObject");

			if (go != null) {
				player = go.transform;
			}
		}
		// At this point we've found player or no player exists.
		if (player == null)
			return;// Try again next frame.

		// Here we know we have a player.
		if (player != null && Vector3.Distance (transform.position, player.position) < 10) {

//			Vector3 pos = transform.position;
//
//			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
//
//			pos += transform.rotation * velocity;
//
//			transform.position = pos;
			rig = transform.GetComponent<Rigidbody2D>();
			rig.AddForce (transform.up * 2 * (maxSpeed));

		}
	}
}

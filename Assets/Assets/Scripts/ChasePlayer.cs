using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {
	public float maxSpeed = 12f;
	public float alertDistance = 14f;

	Transform player;
	Rigidbody2D rig;

	void Start () {
		
	}

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
		if (player != null) {
			float dist = Vector3.Distance (transform.position, player.position);
			if (dist < alertDistance && dist > 3) {
				rig = transform.GetComponent<Rigidbody2D> ();
				rig.AddForce (transform.up * 2 * (maxSpeed));
			}
			if (dist < 3) {
				rig = transform.GetComponent<Rigidbody2D> ();
				rig.AddForce(rig.velocity * -0.3f);
			}
		}
	}
}

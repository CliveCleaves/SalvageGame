using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
	Transform player;
	float rotSpeed = 120f;
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
		if (player != null) {
			
			Vector3 dir = player.position - transform.position;

			dir.Normalize ();

			float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

			Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

			transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
	}
}

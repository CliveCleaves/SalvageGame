using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollide : MonoBehaviour {
	public GameObject smallExplosion;
	public GameObject bigExplosion;
	public GameObject deathSprite;
	public Vector3 explode_pos;

	bool big = true;
	bool deathTrue;
	bool spriteRendered = false;
	Rigidbody2D rig;

	void Start () {
		deathTrue = Camera.main.GetComponent<FollowPlayer> ().deathCam;
		rig = transform.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (explode_pos.x != 0) {
			
			Vector3 world_pos = Camera.main.WorldToScreenPoint (transform.position);
			world_pos.z = -6;
//			world_pos = world_pos * 2;
//			world_pos = new Vector3 (Mathf.Round (world_pos.x), Mathf.Round (world_pos.y), -12);
//			world_pos = world_pos / 2;
//			Debug.Log (world_pos);

			// Debug.Log (explode_pos);
			Vector3 offset = explode_pos - world_pos;
			float dist = Vector3.Distance(explode_pos, world_pos);
			Debug.Log (dist);
			if (dist < 50) {
			//if (world_pos == explode_pos) {
				// We're here!
				Explode (explode_pos);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector3 pos;
		// @TODO We probably don't want to end the game if ANY damage is taken.
		if (col.gameObject.name == "PlayerObject") {
			pos = col.gameObject.transform.position;
			Time.timeScale = 0.2f;
			deathTrue = true;
		} else {
			pos = this.gameObject.transform.position;
		}
		Explode (pos);

	}
	void Explode(Vector3 pos) {
		pos.z = -5;
		rig.velocity = new Vector2 (0, 0);
		GameObject exgo = (GameObject)Instantiate (smallExplosion, pos, transform.rotation);
		if (bigExplosion != null) {
			GameObject ex2go = (GameObject)Instantiate (bigExplosion, pos, transform.rotation);
			Destroy (ex2go, 6f);
		}

		Destroy (exgo, 4f);
		if (deathSprite != null) {
			if (spriteRendered == false) {
				GameObject deathgo = (GameObject)Instantiate (deathSprite, transform.position, transform.rotation);
				spriteRendered = true;
			}
		}
		Destroy (this.gameObject, 0.2f);
	}
}

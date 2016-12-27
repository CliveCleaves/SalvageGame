using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollide : MonoBehaviour {
	public GameObject smallExplosion;
	public GameObject bigExplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D (Collision2D col) {
		Vector3 pos;
		if (col.gameObject.name == "PlayerObject") {
			pos = col.gameObject.transform.position;
			Time.timeScale = 0.2f;
			Camera.main.GetComponent<FollowPlayer> ().deathCam = true;
		} else {
			pos = this.gameObject.transform.position;
		}

		pos.z = -5;
		GameObject exgo = (GameObject)Instantiate (smallExplosion, pos, Quaternion.identity);
		GameObject ex2go = (GameObject)Instantiate (bigExplosion, pos, Quaternion.identity);
		Destroy (exgo, 4f);
		Destroy (ex2go, 4f);
		Destroy (this.gameObject, 0.3f);
	}
}

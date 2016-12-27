using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public GameObject Burning;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.layer == 10) {
			Vector3 pos = transform.position;
			pos.z = -2;
			GameObject go = (GameObject)Instantiate (Burning, pos, Quaternion.identity, this.transform);
			Destroy (this.gameObject.GetComponent<PlayerController> ());
		}
	}
}

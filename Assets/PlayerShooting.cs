using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public GameObject Shell;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("Firing");
			Quaternion rot = Quaternion.identity;
			GameObject shellgo = (GameObject)Instantiate (Shell, transform.position, rot);
		}
	}
}

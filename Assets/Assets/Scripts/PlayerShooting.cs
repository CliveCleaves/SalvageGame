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
			Vector3 pos = transform.position;
			pos.z = -6;
			GameObject shellgo = (GameObject)Instantiate (Shell, pos, transform.rotation);
			Destroy(shellgo, 5f);
		}
	}
}

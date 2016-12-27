using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTorpedos : MonoBehaviour {
	public GameObject torpedo;

	float spawnDistance = 30f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("LaunchProjectile", 2.0f, 10f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void LaunchProjectile () {

		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		offset = offset.normalized * spawnDistance;

		GameObject go = (GameObject)Instantiate (torpedo, transform.position + offset, Quaternion.identity);


	}

}

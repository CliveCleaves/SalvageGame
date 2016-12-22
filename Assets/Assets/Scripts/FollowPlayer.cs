using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform Player;
	float speed = 5f;
	//Transform cameraTrans;
	//Transform Target;
	Vector3 Target;
	// Use this for initialization
	void Start () {
		//cameraTrans = transform;
	}

	void FixedUpdate () {
		Target = Player.position;
		float step = speed * Time.smoothDeltaTime;
		Target.z = -10;
		transform.position = Vector3.Lerp (transform.position, Target, step);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform Player;
	float speed = 5f;

	float duration = 5.0f;
	float elapsed = 0.0f;

	public bool deathCam = false;

	Vector3 Target;

	void Start() {
		Camera.main.orthographic = true;
	}

	void FixedUpdate () {
		if (Player) {
			
			Target = Player.position;
			Target.z = -10;

			float step = speed * Time.smoothDeltaTime;

			transform.position = Vector3.Lerp (transform.position, Target, step);
		}
		if (deathCam == true) {
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.SmoothStep (5f, 2f, 5f * elapsed);
		}
	}
}

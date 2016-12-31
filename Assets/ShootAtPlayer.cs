using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour {
	public float range = 10f;
	public float RPM = 6f;
	float cooldown = 0f;
	public GameObject weapon;
	Transform player;

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
			cooldown -= Time.deltaTime;
			float dist = Vector3.Distance (transform.position, player.position);
			if (dist < range && cooldown <= 0) {
				// Shoot!
				GameObject weaponGo = (GameObject) Instantiate(weapon, transform.position, transform.rotation);
				cooldown = 60 / RPM;
				StartCoroutine(ExecuteAfterTime(1, weaponGo));
			}
		}
	}
	IEnumerator ExecuteAfterTime(float time, GameObject weaponGo) {
		yield return new WaitForSeconds(time);
		BoxCollider2D box = weaponGo.GetComponent<BoxCollider2D> ();
		box.enabled = true;
	}
}

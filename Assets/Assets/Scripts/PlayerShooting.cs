using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public GameObject Shell;
	Vector3 mouse_pos;
	Vector3 object_pos;
	Vector3 explode_pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1")) {
			Vector3 pos = transform.position;
			pos.z = -6;
			GameObject shellgo = (GameObject)Instantiate (Shell, pos, transform.rotation);


			mouse_pos = Input.mousePosition;
			mouse_pos.z = shellgo.transform.position.z;

			mouse_pos =  mouse_pos * 2;
			mouse_pos = new Vector3(Mathf.Round(mouse_pos.x), Mathf.Round(mouse_pos.y), Mathf.Round(mouse_pos.z));
			mouse_pos = mouse_pos / 2;

			shellgo.GetComponent<ExplodeOnCollide> ().explode_pos = mouse_pos;
			Debug.Log (mouse_pos);

			Destroy(shellgo, 5f);
		}
	}
}

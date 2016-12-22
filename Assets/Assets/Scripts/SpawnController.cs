using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	public GameObject WaterPrefab;
	Vector2 currentPos;

	// Use this for initialization
	void Start () {
		LoadWater();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadWater() {
		float rows = 10;
		float columns = 10;
		float rowStart = -50f;
		float columnStart = -50f;
		for (int i = 0; i < rows; i++) {
			for (int n = 0; n < columns; n++) {
				GameObject Water = (GameObject)Instantiate(WaterPrefab, new Vector3((rowStart + (i * 10)), (columnStart + (n * 10)), 0), Quaternion.identity);
				currentPos = new Vector2 (Water.transform.position.x, Water.transform.position.y);
				Water.name = "Water " + currentPos;
				Water.transform.SetParent (transform);
			}
		}
	}
}

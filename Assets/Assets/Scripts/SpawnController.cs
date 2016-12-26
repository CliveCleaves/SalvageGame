using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	public GameObject WaterPrefab;
	public GameObject IslandPrefab;
	public Material islandMaterial;
	Vector2 currentPos;

	void Start () {
		LoadWater();
		SpawnIslands();

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
	void SpawnIslands() {
		// Primitive Islands Using Cylinders.
		float islandCount = Random.Range(3, 10);

		for (int i = 0; i < islandCount; i++) {
			float centerx = Random.Range (-50, 50);
			float centery = Random.Range (-50, 50);
			Quaternion rotation = Quaternion.Euler(new Vector3(270, 0, 0));
			GameObject islandGo = (GameObject)Instantiate (IslandPrefab, new Vector3 (centerx, centery, -0.1f), rotation);
			islandGo.transform.SetParent (transform);
		}
	}
}

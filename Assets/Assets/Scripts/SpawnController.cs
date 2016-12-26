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
	void SpawnIslandsOld() {
		
		//float islandCount = Random.Range(3, 10);
		//for (int i = 0; i < islandCount; i++) {
			float centerx = Random.Range(-50, 50);
			float centery = Random.Range(-50, 50);

		//Vector3[] theVerticies = new Vector3[];

//		theVerticies.SetValue (new Vector3 (centerx, centery, 0), 0);
//		//List<Vector3> theVerticies = new List<Vector3>[];
//			//theVerticies.Add (new Vector3 (centerx, centery, 0));
//			for (int n = 0; n < 10; n++) {
//				//theVerticies.Add(new Vector3 (Random.Range(centerx - 5, centerx + 5), Random.Range(centery - 5, centery + 5), 0));
//				theVerticies.SetValue(new Vector3 (Random.Range(centerx - 5, centerx + 5), Random.Range(centery - 5, centery + 5), 0), n + 1);
//			}
		// @TODO this isn't working. Requires varialbes NOT types.
		// MeshFilter m = new MeshFilter();
		GameObject Island = new GameObject ("Island");
		Vector3 pos = Island.transform.position;
		pos.z = -0.1f;
		Island.transform.position = pos;
		MeshFilter m = (MeshFilter)Island.AddComponent (typeof(MeshFilter));

		m.mesh.Clear();
		//mesh.vertices = new Vector3[] {new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)};
		//m.mesh.vertices = theVerticies;
		float width = 1;
		float height = 1f;
		// @TODO Make this a few more
		m.mesh.vertices = new Vector3[] {
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0),
			new Vector3(Random.Range(centerx - 2, centerx + 2), Random.Range(centery - 2, centery + 2), 0)
//			new Vector3(-width, -height, 0.01f),
//			new Vector3(width, -height, 0.01f),
//			new Vector3(width, height, 0.01f),
//			new Vector3(-width, height, 0.01f)
		};
//		m.mesh.uv = new Vector2[] {
//			new Vector2 (0, 0),
//			new Vector2 (0, 1),
//			new Vector2(1, 1),
//			new Vector2 (1, 0)
//		};
		m.mesh.triangles = getCombinatoric(6);
		Vector3[] normals = new Vector3[4];

		normals[0] = -Vector3.forward;
		normals[1] = -Vector3.forward;
		normals[2] = -Vector3.forward;
		normals[3] = -Vector3.forward;

		m.mesh.normals = normals;
//		m.mesh.triangles = new int[] {
//			0, 1, 2,
//			0, 2, 3,
//			0, 5, 6,
//			2, 4, 6,
//			4, 5, 6,
//			4, 6, 5,
//		};
		m.mesh.RecalculateNormals();

		MeshRenderer renderer = Island.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

		//renderer.material.shader = Shader.Find ("Particles/Additive");
		renderer.material.shader = Shader.Find ("Unlit/Texture");

		Texture2D tex = new Texture2D(1, 1);
		tex.SetPixel(0, 0, new Color32(77, 123, 17, 1));
		//tex.SetPixel(0, 0, Color.);

		tex.Apply();
		//renderer.material.mainTexture = Texture2D.blackTexture;
		renderer.material.mainTexture = tex;
		renderer.material.color = new Color32(77, 123, 17, 1);

		//}
	}

	public int[] getCombinatoric(int count) {
		return new int[] {
			0, 1, 2,
			0, 1, 3,
			0, 1, 4,
			0, 1, 5,
			0, 1, 6,
			0, 2, 3,
			0, 2, 4,
			0, 2, 5,
			0, 2, 6,
			0, 3, 4,
			0, 3, 5,
			0, 3, 6,
			0, 4, 5,
			0, 4, 6,
			0, 5, 6,
			1, 2, 3,
			1, 2, 4,
			1, 2, 5,
			1, 2, 6,
			1, 3, 4,
			1, 3, 5,
			1, 3, 6,
			1, 4, 5,
			1, 4, 6,
			1, 5, 6,
			2, 3, 4,
			2, 3, 5,
			2, 3, 6,
			2, 4, 5,
			2, 4, 6,
			2, 5, 6,
			3, 4, 5,
			3, 4, 6,
			3, 5, 6,
			4, 5, 6	
		};
	}
}

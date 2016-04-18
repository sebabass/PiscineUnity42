using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	public GameObject spawnA;
	public GameObject spawnS;
	public GameObject spawnD;

	public GameObject cubeA;
	public GameObject cubeS;
	public GameObject cubeD;
	
	private float rangSpeedSpawn;
	private float speedSpawnA;
	private float speedSpawnS;
	private float speedSpawnD;
	
	void Start () {
		rangSpeedSpawn = 5.0f;
		speedSpawnA = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
		speedSpawnS = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
		speedSpawnD = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
	}

	void Update () {
		speedSpawnA -= Time.deltaTime;
		speedSpawnS -= Time.deltaTime;
		speedSpawnD -= Time.deltaTime;
		spawnCube ();
	}

	void spawnCube () {
		if (speedSpawnA <= 0) {
			Instantiate(cubeA, new Vector3(spawnA.transform.position.x, spawnA.transform.position.y), Quaternion.identity);
			speedSpawnA = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
		}
		if (speedSpawnS <= 0) {
			Instantiate(cubeS, new Vector3(spawnS.transform.position.x, spawnS.transform.position.y), Quaternion.identity);
			speedSpawnS = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
		}
		if (speedSpawnD <= 0) {
			Instantiate(cubeD, new Vector3(spawnD.transform.position.x, spawnD.transform.position.y), Quaternion.identity);
			speedSpawnD = Random.Range (rangSpeedSpawn - 2.0f, rangSpeedSpawn);
		}
	}
}

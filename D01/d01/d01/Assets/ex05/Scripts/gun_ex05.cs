using UnityEngine;
using System.Collections;

public class gun_ex05 : MonoBehaviour {

	public Transform spawnBullet;
	public GameObject bullet;
	public float intervalShoot;

	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= intervalShoot) {
			Instantiate (bullet, spawnBullet.position, spawnBullet.rotation);
			timer = 0;
		}
	}
}

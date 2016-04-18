using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	public	GameObject	unity;
	public	int		life = 100;
	public	bool		isMain;
	private	float		time;
	public	float		timeSpawn = 0;
	public	House		MainHouse;

	private bool isDestroy;

	private AudioSource audioSrc;
	public AudioClip destroySound;

	// Use this for initialization
	void Start () {
		isDestroy = false;
		audioSrc = gameObject.GetComponent<AudioSource> ();
		time = Time.time;
		if (isMain) {
			life = 400;
			timeSpawn = 10;
		}
	}

	// Update is called once per frame
	void Update () {
		if (life <= 0 && !isDestroy) {
			isDestroy = true;
			if (isMain) {
				if (MainHouse.tag == "OrcHouse")
					Debug.Log ("The Human Team wins.");
				else
					Debug.Log ("The Orc Team wins.");
				Time.timeScale = 0f;

			}
			else
				MainHouse.timeSpawn += 2.5f;
			audioSrc.PlayOneShot(destroySound);
		}

		if (isDestroy && !audioSrc.isPlaying)
			GameObject.Destroy (gameObject);
		if (isMain && Time.time - time >= timeSpawn) {
			time = Time.time;
			spawnUnity();
		}
	}

	void spawnUnity(){
		Instantiate (unity, new Vector3 (transform.position.x + 1f, transform.position.y - 1.4f, 0f), Quaternion.identity);
	}
}

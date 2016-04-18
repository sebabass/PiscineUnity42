using UnityEngine;
using System.Collections;

public class bullet_ex05 : MonoBehaviour {

	private Transform limit;
	private bool isRight;
	private float speedBullet;

	// Use this for initialization
	void Start () {
		isRight = false;
		speedBullet = 5.0f;
		limit = GameObject.Find ("limit").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= limit.position.x)
			GameObject.Destroy (gameObject);
		if (isRight)
			transform.Translate (speedBullet * Time.deltaTime, 0, 0);
		else
			transform.Translate (-speedBullet * Time.deltaTime, 0, 0);
	}

}

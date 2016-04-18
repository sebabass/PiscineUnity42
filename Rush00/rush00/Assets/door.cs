using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public bool isOpen = false;
	public Transform stop;
	public Transform origin;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen) {
			if (transform.position.y > stop.position.y)
				transform.Translate (new Vector3 (0, -2.0f * Time.deltaTime, 0));
			else
				isOpen = false;
		}

		if (!isOpen) {
			if (transform.position.y < origin.position.y) {
				transform.Translate (new Vector3 (0, +2.0f * Time.deltaTime, 0));
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "Player" || coll.transform.tag == "Enemy") {
			isOpen = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {

	public GameObject positionClub;
	private bool canShoot;
	private float distance;
	private float time;

	void Start () {
		canShoot = true;
		distance = 0;
		time = 2.0f;
	}

	void Update () {

		if (canShoot && Input.GetKey ("space")) {
			time = 2.0f;
			if (distance < 1.50f) {
				distance += 0.05f;
				transform.Translate (0, -distance * Time.deltaTime, 0);
			}
		} else if (distance > 0) {
			time -= Time.deltaTime;
			canShoot = false;
			if (time <= 0) {
				Vector3 position = transform.localPosition;
				position.y = Mathf.Clamp(transform.position.y, positionClub.transform.position.y, positionClub.transform.position.y);
				transform.position = position;
				time = 2.0f;
				distance = 0;
				canShoot = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public GameObject borderTop;
	public GameObject borderBottom;
	public GameObject hole;

	private int points;
	private bool canShoot;
	private bool isVictory;
	private int direction;
	private float puissance;
	private float time;

	void Start () {
		canShoot = true;
		isVictory = false;
		puissance = 0;
		direction = 1;
		points = -15;
		time = 2.0f;
	}

	void Update () {
		if (!isVictory) {

			if (canShoot && Input.GetKey ("space")) {
				time = 2.0f;
				if (puissance < 50.0f)
					puissance += 0.5f;
			} else if (puissance > 0) {
				if (canShoot)
					points += 5;
				canShoot = false;
				shoot ();
			} else {
				time -= Time.deltaTime;
				checkHoleDirection ();
				if (time <= 0) {
					canShoot = true;
					puissance = 0;
					time = 2.0f;
				}
			}
		}
	}

	void checkHoleDirection () {
		if (hole.transform.position.y + 0.3 > transform.position.y && hole.transform.position.y - 0.3 < transform.position.y && puissance < 25.0f) {
			Vector3 position = transform.localPosition;
			position.y = hole.transform.position.y;
			transform.position = position;
			if (points > 0)
				Debug.Log("Perdu :(");
			Debug.Log ("Score: " + points);
			isVictory = true;
		}

		if (hole.transform.position.y > transform.position.y)
			direction = 1;
		else
			direction = -1;
	}

	void shoot () {

		if (direction == 1 && transform.position.y >= borderTop.transform.position.y)
			direction = -1;
		if (direction == -1 && transform.position.y <= borderBottom.transform.position.y)
			direction = 1;

		if (direction == 1) {
			transform.Translate (0, puissance * Time.deltaTime, 0);
		} else {
			transform.Translate (0, -puissance * Time.deltaTime, 0);
		}
		puissance -= 1.0f;
	}
}

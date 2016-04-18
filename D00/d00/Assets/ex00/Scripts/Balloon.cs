using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	
	public float timeGameOver = 30.0f;

	private bool isUpBalloon;
	private bool isGetKeyDownSpace;
	private float success;
	private int air = 100;

	// Timer
	private float timeRegen;
	private	float timeBalloonLife;
	private float vitesseInput;
	private float vitesseBalloonDown;

	void Start () {
		isUpBalloon = true;
		isGetKeyDownSpace = false;
		success = 5.0F;

		// Timer
		timeRegen = 5.0f;
		timeBalloonLife = 0;
		vitesseInput = 0;
		vitesseBalloonDown = 2f;
	}
	
	void Update () {
		timeBalloonLife += Time.deltaTime;
		if (!isUpBalloon)
			airRegen();
		else
			vitesseInput += Time.deltaTime;
		if (Input.GetKeyDown ("space")) {
			isGetKeyDownSpace = true;
			upBalloon ();
		}
		downBalloon ();
		checkGameOver();
	}

	void upBalloon () {
		if (isUpBalloon) {
			gameObject.transform.localScale += new Vector3 (0.05F + (vitesseInput / 10), 0.05F + (vitesseInput / 10), 0);
			air -= (vitesseInput > 5.0f) ? 1 : (5 - Mathf.RoundToInt(vitesseInput));
			vitesseInput = 0;
		}
		if (Mathf.RoundToInt (gameObject.transform.localScale.x) >= success && Mathf.RoundToInt (gameObject.transform.localScale.y) >= success) {
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(timeBalloonLife) + "s");
			GameObject.Destroy (gameObject);
		}
		if (isUpBalloon && air <= 0) {
			Debug.Log ("Wait " + Mathf.RoundToInt(timeRegen) + "s");
			isUpBalloon = false;
		}
		isGetKeyDownSpace = false;
	}

	void airRegen() {
		timeRegen -= Time.deltaTime;
		if (timeRegen <= 0) {
			isUpBalloon = true;
			timeRegen = 5.0f;
			air = 100;
			Debug.Log ("blow the balloon!!!");
		}
	}

	void downBalloon () {
		if (isGetKeyDownSpace)
			return;
		float tmp = 0.05f;
		vitesseBalloonDown -= Time.deltaTime;
		if (vitesseBalloonDown <= 0) {
			if (gameObject.transform.localScale.x - tmp <= 1.0f || gameObject.transform.localScale.y <= 1.0f)
				gameObject.transform.localScale = new Vector3 (1, 1, 0);
			else
				gameObject.transform.localScale -= new Vector3 (tmp, tmp, 0);
			vitesseBalloonDown = 2f;
		}
	}

	void checkGameOver() {
		timeGameOver -= Time.deltaTime;
		if (timeGameOver <= 0) {
			Debug.Log("Game over");
			GameObject.Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public GameObject deathYTop;
	public GameObject deathYGround;
	public GameObject pipe1;
	public GameObject pipe2;
	public GameObject deathPipeTop;
	public GameObject deathPipeBottom;

	private float timeDown;
	private bool startGame;
	private int point;
	private float time;
	private bool isDeath;
	private bool pointPipe1;
	private bool pointPipe2;

	// Use this for initialization
	void Start () {
		isDeath = false;
		startGame = false;
		point = 0;
		time = 0;
		timeDown = 0.2f;
		pointPipe1 = false;
		pointPipe2 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDeath) {
			if (!startGame && Input.GetKeyDown ("space")) {
				startGame = true;
			}
			if (startGame) {
				isBirdDeath();
				time += Time.deltaTime;
				timeDown -= Time.deltaTime * 8;
				if (Input.GetKeyDown ("space")) {
					upBird ();
				}
				if (timeDown <= 0) {
					transform.Translate (0, -8.0f * Time.deltaTime, 0);
				}
			}
		}
	}

	void upBird() {
		transform.Translate (0, 60.0f * Time.deltaTime, 0);
		timeDown = 2.0f;
	}

	void isBirdDeath() {
		if (transform.position.y >= deathYTop.transform.position.y)
			death ();
		else if (transform.position.y <= deathYGround.transform.position.y)
			death ();
		else if (transform.position.x >= pipe1.transform.position.x - 0.5f && transform.position.x <= pipe1.transform.position.x + 0.5f) {
			if (transform.position.y >= deathPipeTop.transform.position.y)
				death ();
			else if (transform.position.y <= deathPipeBottom.transform.position.y)
				death ();
		} else if (transform.position.x >= pipe2.transform.position.x - 0.5f && transform.position.x <= pipe2.transform.position.x + 0.5f) {
			if (transform.position.y >= deathPipeTop.transform.position.y)
				death ();
			else if (transform.position.y <= deathPipeBottom.transform.position.y)
				death ();
		} else if (transform.position.y < deathPipeTop.transform.position.y && transform.position.y > deathPipeBottom.transform.position.y) {
			if (pointPipe1 && transform.position.x >= pipe1.transform.position.x) {
				point += 5;
				pointPipe1 = false;
				pointPipe2 = true;
			} else if (pointPipe2 && transform.position.x >= pipe2.transform.position.x) {
				point += 5;
				pointPipe1 = true;
				pointPipe2 = false;
			}
		}
	}

	void death() {
		Debug.Log ("Score: " + point);
		Debug.Log ("Time: " + Mathf.RoundToInt (time) + "s");
		isDeath = true;
	}
}

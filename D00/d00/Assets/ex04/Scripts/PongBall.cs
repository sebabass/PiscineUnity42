using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour {

	public GameObject playerLeft;
	public GameObject playerRight;
	public GameObject borderTop;
	public GameObject borderBottom;
	private float speedBall;
	private int directionX;
	private int directionY;
	private int randomX;
	private int randomY;
	private int pointPlayer1;
	private int pointPlayer2;
	// Use this for initialization
	void Start () {
		randomDirection ();
		speedBall = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkPoint ();
		moveBall ();
		checkCollision ();
	}

	void randomDirection () {
		randomX = Random.Range (0, 10);
		if (randomX % 2 == 0)
			directionX = 1;
		else
			directionX = -1;
		randomY = Random.Range (0, 10);
		if (randomY % 2 == 0)
			directionY = 1;
		else
			directionY = -1;
	}

	void checkCollision () {

		if (transform.position.y + 0.2f >= borderTop.transform.position.y - 0.2f)
			directionY = -1;
		else if (transform.position.y - 0.2f <= borderBottom.transform.position.y + 0.2f)
			directionY = 1;
		else if (transform.position.x - 0.2f <= playerLeft.transform.position.x + 0.2f) {
			if (transform.position.y <= playerLeft.transform.position.y + 1.0f && transform.position.y >= playerLeft.transform.position.y) {
				directionX = 1;
				directionY = 1;
			} else if (transform.position.y >= playerLeft.transform.position.y - 1.0f && transform.position.y < playerLeft.transform.position.y) {
				directionX = 1;
				directionY = -1;
			}
		} else if (transform.position.x + 0.2f >= playerRight.transform.position.x - 0.2f) {
			if (transform.position.y <= playerRight.transform.position.y + 1.0f && transform.position.y >= playerRight.transform.position.y) {
				directionX = -1;
				directionY = 1;
			} else if (transform.position.y >= playerRight.transform.position.y - 1.0f && transform.position.y < playerRight.transform.position.y) {
				directionX = -1;
				directionY = -1;
			}
		}
	}

	void moveBall() {
		float speedTmpX = speedBall;
		float speedTmpY = speedBall;

		if (directionX == -1)
			speedTmpX = speedBall - (speedBall * 2); 
		if (directionY == -1)
			speedTmpY = -speedBall - (speedBall * 2);

		transform.Translate (speedTmpX * Time.deltaTime, speedTmpY * Time.deltaTime, 0);
	}

	void checkPoint () {

		if (transform.position.x <= playerLeft.transform.position.x && transform.position.y - 0.2f > playerLeft.transform.position.y + 1.0f)
			addPoint("Player2");
		else if (transform.position.x <= playerLeft.transform.position.x && transform.position.y + 0.2f < playerLeft.transform.position.y - 1.0f)
			addPoint("Player2");
		else if (transform.position.x >= playerRight.transform.position.x && transform.position.y - 0.2f > playerRight.transform.position.y + 1.0f)
			addPoint("Player1");
		else if (transform.position.x >= playerRight.transform.position.x && transform.position.y + 0.2f < playerRight.transform.position.y - 1.0f)
			addPoint("Player1");
	}

	void addPoint (string player) {

		if (player == "Player1")
			pointPlayer1++;
		else
			pointPlayer2++;
		Debug.Log ("Player 1: " + pointPlayer1 + " | Player 2: " + pointPlayer2);
		randomDirection ();
		Vector3 position = transform.position;
		position.x = 0;
		position.y = 0;
		transform.position = position;
	}
}

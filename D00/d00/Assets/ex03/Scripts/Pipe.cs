using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public GameObject pipe1;
	public GameObject pipe2;
	public GameObject beginPipe;
	public GameObject flappyBird;
	private float speed;
	private bool startGame;
	private bool isGoodPipe1;
	private bool isGoodPipe2;

	// Use this for initialization
	void Start () {
		startGame = false;
		speed = 0.0f;
		isGoodPipe1 = false;
		isGoodPipe1 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!startGame && Input.GetKeyDown ("space")) {
			startGame = true;
			speed = 3.0f;
		}
		if (pipe1.transform.position.x <= -12.0f) {
			Vector3 position = pipe1.transform.localPosition;
			position.x = beginPipe.transform.position.x;
			pipe1.transform.position = position;
			isGoodPipe1 = false;
		}
		if (pipe2.transform.position.x <= -12.0f) {
			Vector3 position = pipe2.transform.localPosition;
			position.x = beginPipe.transform.position.x;
			pipe2.transform.position = position;
			isGoodPipe2 = false;
		}

		if (!isGoodPipe1 && flappyBird.transform.position.x >= pipe1.transform.position.x) {
			isGoodPipe1 = true;
			speed += 0.2f;
		}
		if (!isGoodPipe2 && flappyBird.transform.position.x >= pipe2.transform.position.x) {
			isGoodPipe2 = true;
			speed += 0.2f;
		}
		pipe1.transform.Translate (-speed * Time.deltaTime, 0, 0);
		pipe2.transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
}

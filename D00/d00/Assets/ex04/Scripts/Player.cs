using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject top;
	public GameObject bottom;
	private float speedMove;
	public KeyCode keyUp;
	public KeyCode keyDown;

	// Use this for initialization
	void Start () {
		speedMove = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (keyUp)) {
			if (transform.position.y + 1.0f < top.transform.position.y)
				transform.Translate (0, speedMove * Time.deltaTime, 0);
		} else if (Input.GetKey (keyDown)) {
			if (transform.position.y - 1.0f > bottom.transform.position.y)
				transform.Translate (0, -speedMove * Time.deltaTime, 0);
		}
	}
}

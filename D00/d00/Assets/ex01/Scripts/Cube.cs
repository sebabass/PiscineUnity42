using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject lineBottom;
	public string key;
	private float speedCube;
	private float topLine;
	private float bottomLine;
	private float centerBottom;
	
	void Start () {
		speedCube = Random.Range(2.0f, 5.0f);
		topLine = lineBottom.transform.position.y + 0.2f;
		bottomLine = lineBottom.transform.position.y - 1.2f;
		centerBottom = lineBottom.transform.position.y;
	}

	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * speedCube);
		if (Input.GetKeyDown (key) && transform.position.y < topLine && transform.position.y > bottomLine) {
			getPrecision();
		}
		if (transform.position.y < bottomLine - 5f) {
			Debug.Log ("Noob!!!");
			GameObject.Destroy (gameObject);
		}
	}

	void getPrecision() {
		if (transform.position.y > centerBottom) {
			Debug.Log ("Precision: " + (transform.position.y - centerBottom));
		} else {
			Debug.Log ("Precision: " + (centerBottom - transform.position.y));
		}
		GameObject.Destroy (gameObject);
	}
}

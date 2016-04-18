using UnityEngine;
using System.Collections;

public class plateform_ex03 : MonoBehaviour {
	
	public float speed;
	public float maxDistance;
	public bool isUpOrRight;
	public bool isTop;

	private Vector2 pointInit;
	// Use this for initialization
	void Start () {
		pointInit = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		checkDistance ();
		movePlateform ();
	}

	void checkDistance () {
		if (isUpOrRight) {
			if (isTop && transform.position.y >= maxDistance)
				isUpOrRight = false;
			else if (!isTop && transform.position.x >= maxDistance)
				isUpOrRight = false;
		} else {
			if (isTop && transform.position.y <= pointInit.y)
				isUpOrRight = true;
			else if (!isTop && transform.position.x <= pointInit.x)
				isUpOrRight = true;
		}
	}

	void movePlateform () {
		if (isUpOrRight) {
			if (isTop)
				transform.Translate (0, speed * Time.deltaTime, 0);
			else
				transform.Translate (speed * Time.deltaTime, 0, 0);
		} else {
			if (isTop)
				transform.Translate (0, -speed * Time.deltaTime, 0);
			else
				transform.Translate (-speed * Time.deltaTime, 0, 0);
		}
	}
	
}

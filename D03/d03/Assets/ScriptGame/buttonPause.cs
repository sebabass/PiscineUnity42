using UnityEngine;
using System.Collections;

public class buttonPause : MonoBehaviour {
		
	private float timeScale;

	void Start () {
		timeScale = Time.timeScale;
	}

	public void speedUp () {
		if (Time.timeScale < timeScale + 3.0f && !gameManager.gm.pauseBool) {
			gameManager.gm.changeSpeed (Time.timeScale + 2.0f);
		}
	}

	public void speedDown () {
		if (Time.timeScale > 2.0f && !gameManager.gm.pauseBool) {
			gameManager.gm.changeSpeed (Time.timeScale - 2.0f);
		} else {
			gameManager.gm.pauseBool = false;
			gameManager.gm.changeSpeed (timeScale);
		}
	}

	public void pause () {
		gameManager.gm.pauseBool = !gameManager.gm.pauseBool;
		gameManager.gm.pause (gameManager.gm.pauseBool);
	}


}

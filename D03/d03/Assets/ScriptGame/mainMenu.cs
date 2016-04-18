using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public void loadLevel (int level) {
		Application.LoadLevel (level);
	}

	public void quitLevel () {
		Application.Quit ();
	}

	public void continuePause () {
		gameManager.gm.pause (false);
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.Find ("Panel").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void quitPause () {
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void confirmQuitPause () {
		loadLevel(0);
	}

	public void noQuitPause () {
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

}

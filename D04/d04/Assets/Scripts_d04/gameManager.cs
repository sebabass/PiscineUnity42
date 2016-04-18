using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	// Public
	public Text textTimer;
	public Text textNbRings;
	public Text textEnemyDead;
	public Text textNbRingsFinal;
	public Text textTimeFinal;
	public Text textScore;
	public static gameManager gm;

	// Private
	private float time = 0;
	private int minutes = 0;
	private int secondes = 0;
	private int score = 0;
	[HideInInspector]public bool sign = false;


	void Awake () {
		if (gm == null)
			gm = this;
	}

	// Update is called once per frame
	void Update () {
		if (!sign)
			updateTime ();
		else {
			if (Input.GetKeyDown(KeyCode.Return))
				Application.LoadLevel(1);
		}
	}

	void updateTime () {
		time += Time.deltaTime;

		minutes = Mathf.RoundToInt(time / 60.0f);
		secondes = Mathf.RoundToInt (time % 60.0f);
		if (secondes < 10)
			textTimer.text = minutes.ToString () + ": 0" + secondes.ToString ();
		else
			textTimer.text = minutes.ToString () + ": " + secondes.ToString ();
	}

	public void updateUI() {
		textNbRings.text = Sonic.sn.rings.ToString ();
	}

	public void addMenuScore () {
		GameObject.Find ("mainPanel").GetComponent<CanvasGroup> ().alpha = 0;
		GameObject.Find ("scorePanel").GetComponent<CanvasGroup> ().alpha = 1;
		int tmp = 0;
		if (secondes < 200)
			tmp = (20000 - (100 * secondes));
		score = (500 * Sonic.sn.enemyDead) + (100 * Sonic.sn.rings) + tmp;
		if (score > user.us.GetScoreRun (Application.loadedLevel - 2))
			user.us.UpdateScoreRun (score, Application.loadedLevel - 2);
		textEnemyDead.text = "Enemy dead: " + Sonic.sn.enemyDead.ToString() + " => " + (500 * Sonic.sn.enemyDead).ToString();
		textNbRingsFinal.text = "Rings: " + Sonic.sn.rings.ToString() + " => " + (100 * Sonic.sn.rings).ToString();
		if (secondes < 10)
			textTimeFinal.text = "Time " + minutes.ToString () + ":0" + secondes.ToString () + " => " + tmp.ToString(); 
		else
			textTimeFinal.text = "Time " + minutes.ToString () + ":" + secondes.ToString () + " => " + tmp.ToString(); 
		textScore.text = score.ToString ();
		user.us.UpdateLevelUnlock ((Application.loadedLevel - 2) + 1);
		user.us.Save ();
	}
}

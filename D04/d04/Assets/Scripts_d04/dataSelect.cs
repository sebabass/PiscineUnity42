using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dataSelect : MonoBehaviour {

	// Public
	public Sprite 	spriteNone;
	public Sprite	spriteLock;
	public Sprite   spriteSelected;
	public Image[]	imageLevel;
	public Sprite[]	spriteLevel;
	public string[]	nameLevel;

	public Text		nameLevelText;
	public Text		scoreText;
	public Text		ringsText;
	public Text 	lifeLostText;

	// Private
	private int 	levelSelected;
	private int		nbLevel = 12;

	// Use this for initialization
	void Start () {

		for (int i=0; i < nbLevel; i++) {
			if (user.us.GetLevelUnlock(i) == 1)
				imageLevel[i].sprite = spriteLevel[i];
			else
				imageLevel[i].sprite = spriteLock;
		}
		levelSelected = 0;
		loadText ();
	}

	void Update () {

		nameLevelText.text = nameLevel [levelSelected];
		imageLevel [levelSelected].transform.GetChild (0).GetComponent<Image> ().sprite = spriteSelected;

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (levelSelected + 1 > nbLevel - 1)
				levelSelected = nbLevel - 1;
			else {
				imageLevel [levelSelected].transform.GetChild (0).GetComponent<Image> ().sprite = spriteNone;
				levelSelected++;
				loadText ();
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (levelSelected - 1 < 0) {
				levelSelected = 0;
			} else {
				imageLevel [levelSelected].transform.GetChild (0).GetComponent<Image> ().sprite = spriteNone;
				levelSelected--;
				loadText ();
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (levelSelected <= nbLevel - 1 && levelSelected > nbLevel - 5 || levelSelected <= nbLevel - 5 && levelSelected > nbLevel - 9) {
				imageLevel [levelSelected].transform.GetChild (0).GetComponent<Image> ().sprite = spriteNone;
				levelSelected -= 4;
				loadText ();
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (levelSelected >= 0  && levelSelected < 4|| levelSelected >= 4 && levelSelected < 8) {
				imageLevel [levelSelected].transform.GetChild (0).GetComponent<Image> ().sprite = spriteNone;
				levelSelected += 4;
				loadText ();
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel (0);

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (user.us.isLevelUnlock(levelSelected))
				Application.LoadLevel(levelSelected + 2);
		}
	}

	void loadText () {
		scoreText.text = "Score: " + user.us.GetScoreRun(levelSelected).ToString();
		ringsText.text = user.us.GetNbRings ().ToString();
		lifeLostText.text = user.us.GetNbLifeLost().ToString();
	}
}

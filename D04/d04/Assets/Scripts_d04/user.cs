using UnityEngine;
using System.Collections;

public class user : MonoBehaviour {

	// Public
	public static user us;

	// Private
	private int nbLifeLost = 0;
	private int nbRings = 0;
	private int[] scoresRun = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	private int[] levelUnlock = new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

	void Awake () {
		if (us == null)
			us = this;
	}

	void Start () {

		if (PlayerPrefs.HasKey ("nbLifeLost"))
			nbLifeLost = PlayerPrefs.GetInt ("nbLifeLost");

		if (PlayerPrefs.HasKey ("nbRings"))
			nbRings = PlayerPrefs.GetInt ("nbRings");

		for(int i=0;i<2;i++) {
			if (PlayerPrefs.HasKey(i + "scoreRun"))
				scoresRun[i] = PlayerPrefs.GetInt(i.ToString() + "scoreRun");
		}

		for (int i=0; i<2; i++) {
			if (PlayerPrefs.HasKey(i + "levelUnlock"))
				levelUnlock[i] = PlayerPrefs.GetInt(i.ToString() + "levelUnlock");
		}
	}

	public void UpdateNbLifeLost () {
		if (PlayerPrefs.HasKey ("nbLifeLost"))
			nbLifeLost = PlayerPrefs.GetInt ("nbLifeLost");
		PlayerPrefs.SetInt ("nbLifeLose", nbLifeLost + 1);
	}

	public void UpdateNbRings () {
		if (PlayerPrefs.HasKey ("nbRings"))
			nbRings = PlayerPrefs.GetInt ("nbRings");
		PlayerPrefs.SetInt ("nbRings", nbRings + 1);
	}

	public void UpdateScoreRun (int newScoreRun, int level) {
		PlayerPrefs.SetInt(level.ToString() + "scoreRun", newScoreRun);
	}

	public void UpdateLevelUnlock (int level) {
		PlayerPrefs.SetInt(level.ToString() + "levelUnlock", 1);
	}

	public int GetNbLifeLost () {
		if (PlayerPrefs.HasKey ("nbLifeLost"))
			nbLifeLost = PlayerPrefs.GetInt ("nbLifeLost");
		return nbLifeLost;
	}

	public int GetNbRings () {
		if (PlayerPrefs.HasKey ("nbRings"))
			nbRings = PlayerPrefs.GetInt ("nbRings");
		return nbRings;
	}

	public int GetScoreRun (int level) {
		return scoresRun [level];
	}

	public int GetLevelUnlock (int level) {
		return levelUnlock[level];
	}

	public bool isLevelUnlock (int level) {
		return (levelUnlock [level] == 1);
	}

	public void Save () {
		PlayerPrefs.Save ();
	}

	public void Reset () {
		PlayerPrefs.DeleteAll ();
	}
}

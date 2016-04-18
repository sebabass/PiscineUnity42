using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
	public Text Start_Game;
	public Text exit;
	private int selected;
	
	// Use this for initialization
	void Start () {
		selected =  0;
	}
	
	// Update is called once per frame
	void Update () {	
		if (selected == 0) {
			Start_Game.color = Color.red;
			exit.color = Color.black;

		} else {
			Start_Game.color = Color.black;
			exit.color = Color.red;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
			if(selected == 0)
				selected = 1;
			else
				selected = 0;
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(selected == 0)
				Application.LoadLevel(1);
			else
				Application.Quit();
		}
		if (Input.GetMouseButtonDown(0) && selected == 0)
			Application.LoadLevel(1);
		else if(Input.GetMouseButtonDown(0) && selected == 1)
			Application.Quit();
	}
}

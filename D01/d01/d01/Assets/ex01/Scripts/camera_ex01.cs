using UnityEngine;
using System.Collections;

public class camera_ex01 : MonoBehaviour {

	public GameObject john;
	public GameObject claire;
	public GameObject thomas;
	public KeyCode selectedJohn;
	public KeyCode selectedClaire;
	public KeyCode selectedThomas;
	
	private int player;
	
	// Use this for initialization
	void Start () {
		if (john.GetComponent<playerScript_ex01> ().isCurrentPlayer)
			selectJohn ();
		else if (claire.GetComponent<playerScript_ex01> ().isCurrentPlayer)
			selectClaire ();
		else
			selectThomas ();
	}
	
	// Update is called once per frame
	void Update () {
		changePlayer ();
		if (Input.GetKeyDown("r"))
			Application.LoadLevel(1);
		if (player == 1)
			selectJohn ();
		else if (player == 2)
			selectClaire ();
		else
			selectThomas ();
	}
	
	void changePlayer () {
		if (Input.GetKeyDown (selectedJohn))
			player = 1;
		if (Input.GetKeyDown (selectedClaire))
			player = 2;
		if (Input.GetKeyDown (selectedThomas))
			player = 3;
	}
	
	void selectJohn() {
		Vector3 position = transform.position;
		position.x = john.transform.position.x;
		position.y = john.transform.position.y;
		transform.position = position;
	}
	
	void selectClaire() {
		Vector3 position = transform.position;
		position.x = claire.transform.position.x;
		position.y = claire.transform.position.y;
		transform.position = position;
	}
	
	void selectThomas() {
		Vector3 position = transform.position;
		position.x = thomas.transform.position.x;
		position.y = thomas.transform.position.y;
		transform.position = position;
	}
}

using UnityEngine;
using System.Collections;

public class game_ex05 : MonoBehaviour {

	public GameObject winOther1;
	public GameObject winOther2;
	public bool playerVictory;
	
	private bool isWinThomas;
	private bool isWinJohn;
	private bool isWinClaire;
	
	
	// Use this for initialization
	void Start () {
		isWinThomas = false;
		isWinJohn = false;
		isWinClaire = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isWinThomas && isWinJohn && isWinClaire && playerVictory) {
			Debug.Log ("Victoire");
			Application.LoadLevel(1);
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (name == "red_exit" && col.name == "Thomas") {
				isWinThomas = true;
				winOther1.GetComponent<game_ex05>().setVictoryThomas(true);
				winOther2.GetComponent<game_ex05>().setVictoryThomas(true);
			}
			else if (name == "yellow_exit" && col.name == "John") {
				isWinJohn = true;
				winOther1.GetComponent<game_ex05>().setVictoryJohn(true);
				winOther2.GetComponent<game_ex05>().setVictoryJohn(true);
			}
			else if (name == "blue_exit" && col.name == "Claire")  {
				isWinClaire = true;
				winOther1.GetComponent<game_ex05>().setVictoryClaire(true);
				winOther2.GetComponent<game_ex05>().setVictoryClaire(true);
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (name == "red_exit" && col.name == "Thomas") {
				isWinThomas = false;
				winOther1.GetComponent<game_ex05>().setVictoryThomas(false);
				winOther2.GetComponent<game_ex05>().setVictoryThomas(false);
			}
			else if (name == "yellow_exit" && col.name == "John") {
				isWinJohn = false;
				winOther1.GetComponent<game_ex05>().setVictoryJohn(false);
				winOther2.GetComponent<game_ex05>().setVictoryJohn(false);
			}
			else if (name == "blue_exit" && col.name == "Claire")  {
				isWinClaire = false;
				winOther1.GetComponent<game_ex05>().setVictoryClaire(false);
				winOther2.GetComponent<game_ex05>().setVictoryClaire(false);
			}
			
		}
	}
	
	public void setVictoryThomas (bool thomas) {
		isWinThomas = thomas;
	}
	
	public void setVictoryJohn (bool john) {
		isWinJohn = john;
	}
	
	public void setVictoryClaire (bool claire) {
		isWinClaire = claire;
	}
}

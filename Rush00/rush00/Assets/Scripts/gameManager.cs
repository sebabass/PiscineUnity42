using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager gm;
	public int nbEnemy;

	void Awake () {
		if (gm == null)
			gm = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (nbEnemy <= 0)
			Application.LoadLevel (0);
	}

	public void removeEnemy () {
		nbEnemy--;
	}
}

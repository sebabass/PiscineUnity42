﻿using UnityEngine;
using System.Collections;

public class mainTitle : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			Application.LoadLevel (1);
	}
}

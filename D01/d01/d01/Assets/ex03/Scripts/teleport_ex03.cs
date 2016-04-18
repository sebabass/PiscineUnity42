using UnityEngine;
using System.Collections;

public class teleport_ex03 : MonoBehaviour {

	public Transform teleportOut;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			col.transform.localPosition = teleportOut.position;
		}
	}
}

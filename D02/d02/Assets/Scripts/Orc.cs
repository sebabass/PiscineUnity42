using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orc : MonoBehaviour {

	public int	life = 50;
	private AudioSource audioSrc;
	public AudioClip deadSound;
	public	House		MainHouse;
	// Animation
	private Animator animate;
	private Vector3	mousePosition;
	private int   	time;
	
	// Control
	private bool selected;
	private GameObject cible;

	private bool isdead;

	void Start () {
		audioSrc = gameObject.GetComponent<AudioSource> ();
		isdead = false;
	}

	void Update () {
		if (life <= 0 && !isdead) {
			isdead = true;
			audioSrc.PlayOneShot(deadSound);
		}
		if (isdead && !audioSrc.isPlaying)
			GameObject.Destroy (gameObject);
	}
}
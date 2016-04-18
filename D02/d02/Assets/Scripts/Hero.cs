using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	// Animation
	private Animator animate;
	private Vector3	mousePosition;
	private int   	time;

	// Control
	private bool selected;
	private GameObject cible;

	private AudioSource audioSrc;
	public AudioClip attackSound;


	// Use this for initialization
	void Start () {
		this.audioSrc = gameObject.GetComponent<AudioSource> ();
		this.cible = null;
		this.selected = false;
		this.animate = gameObject.GetComponent<Animator> ();

		this.animate.SetBool ("isWalking", false);
		time = Mathf.RoundToInt(Time.time);
	}

	public void    rotateHero(Vector3 pToGo)
	{
		Vector3 lookPos = pToGo - transform.position;
		
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}

	// Update is called once per frame
	void Update () {
		if (cible && cible.transform.position != transform.position)
			moveToPoint(0f, 0f);
		else if (cible == null)
			animate.SetBool ("isFighting", false);
		if (this.transform.position == this.mousePosition)
			this.animate.SetBool ("isWalking", false);
		if (this.animate.GetBool("isWalking")) {
			float step = 2 * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.mousePosition, step);
		}
	}

	public void moveToPoint (float pMouseX, float pMouseY) {
		if (cible)
			mousePosition = cible.transform.position;
		else {
			this.mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (pMouseX, pMouseY, 0));
			this.mousePosition.z = 0;
		}
		rotateHero (this.mousePosition);
		animate.SetBool ("isWalking", true);
	}

	// Setter
	public void setSelected(bool pSelected) {
		this.selected = pSelected;
	}

	public void setCible(GameObject target) {
		this.cible = target;
	}

	// Getter
	public bool isSelected() {
		return this.selected;
	}

	public void OnTriggerStay2D(Collider2D collider) {
		if ((collider.transform.CompareTag("OrcHouse") || collider.transform.CompareTag("Orc")) && cible && cible.gameObject == collider.gameObject)
		{
			animate.SetBool ("isFighting", true);
			animate.SetBool ("isWalking", false);
			this.mousePosition = this.transform.position;

			if (Mathf.RoundToInt(Time.time) - time > 1) {
				if (collider.transform.CompareTag("OrcHouse")) {
					collider.gameObject.GetComponent<House>().life -= 5;
					if (collider.transform.name == "MainHouse")
						Debug.Log ("Town hall Orc [" + cible.GetComponent<House> ().life + "/400]HP has been attacked." );
					else
						Debug.Log ("House Orc [" + cible.GetComponent<House> ().life + "/100]HP has been attacked." );
				}
				else {
					collider.gameObject.GetComponent<Orc>().life -= 10;
					Debug.Log ("Orc Unit [" + cible.GetComponent<Orc>().life + "/50]HP has been attacked." );
				}
				audioSrc.PlayOneShot(attackSound);
				time = Mathf.RoundToInt(Time.time);
			}
		}
	}

	public void OnTriggerExit2D(Collider2D collider)
	{
		animate.SetBool ("isFighting", false);
	}
}

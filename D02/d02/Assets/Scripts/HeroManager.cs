using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroManager : MonoBehaviour {

	private AudioSource audioSrc;
	public AudioClip yesSound;

	public List<Hero> heros = new List<Hero>();

	// Use this for initialization
	void Start () {
		this.audioSrc = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
			if (hit)
			{
				if (hit.transform.tag == "Hero")
				{
					Hero hero = hit.transform.GetComponent<Hero>();
					if (heros.Count > 0 && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
						heros.Clear();
					hero.setSelected(true);
					heros.Add(hero);

				}
				else if (hit.transform.tag == "Orc" || hit.transform.tag == "OrcHouse") {
					foreach(Hero h in heros) {
						h.setCible(hit.collider.gameObject);
						h.moveToPoint(hit.transform.position.x, hit.transform.position.y);
						audioSrc.PlayOneShot (yesSound);
					}
				}
			}
			else {
				foreach (Hero h in heros) {
					h.setCible(null);
					h.moveToPoint(Input.mousePosition.x, Input.mousePosition.y);
					audioSrc.PlayOneShot (yesSound);
				}
			}
		}
		if (Input.GetMouseButtonDown (1) && heros.Count > 0)
			heros.Clear ();
	}
}

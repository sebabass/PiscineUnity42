using UnityEngine;
using System.Collections;

public class spawnWeapon : MonoBehaviour {

	public weapon weap;
	public Sprite[] listWeapon;
	public Sprite[] attachedWeapon;
	public Sprite[] bulletWeapon;
	public int[] ammoWeapon;
	public float[] rateWeapon;
	public float[] distanceWeapon;
	public AudioClip[] soundWeapon;

	// Use this for initialization
	void Start () {
		int rand = 0;
		rand = Random.Range (0, 12);
		Instantiate (weap, new Vector3(transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
		weap.spriteWeapon = listWeapon [rand];
		weap.attachedWeapon = attachedWeapon [rand];
		weap.bulletWeapon = bulletWeapon [rand];
		weap.ammoWeapon = ammoWeapon [rand];
		weap.rateWeapon = rateWeapon [rand];
		weap.distanceWeapon = distanceWeapon [rand];
		weap.WeaponSprite.sprite = listWeapon [rand];
		weap.soundWeapon = soundWeapon[rand];
	}


}

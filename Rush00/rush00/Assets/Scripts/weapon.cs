using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	public Sprite spriteWeapon;
	public Sprite attachedWeapon;
	public Sprite bulletWeapon;
	public int ammoWeapon;
	public float rateWeapon;
	public float distanceWeapon;
	public SpriteRenderer WeaponSprite;
	public AudioClip soundWeapon;
		

	public float getDistanceWeapon () {
		return distanceWeapon;
	}

	public int getAmmoWeapon()  {
		return ammoWeapon;
	}

	public float getRateWeapon()  {
		return rateWeapon;
	}

	public Sprite getBulletWeapon () {
		return bulletWeapon;
	}

	public Sprite getAttachedWeapon () {
		return attachedWeapon;
	}

	public void setAmmoWeapon( int ammo)  {
		ammoWeapon = ammo;
	}

	public AudioClip getSoundWeapon () {
		return soundWeapon;
	}
}

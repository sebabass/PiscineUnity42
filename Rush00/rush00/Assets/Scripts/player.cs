using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public Sprite[] listHead;
	public Sprite[] listBody;
	public SpriteRenderer Head;
	public SpriteRenderer Body;
	public SpriteRenderer WeaponSprite;
	public float speed;
	public Animator walk;
	bool hitWeapon = false;
	private AudioSource aSrc;
	

	private bool isDrop = false;
	private Rigidbody2D rg2d;


	// weapon
	private bool isWeapon = false;
	public GameObject positionBullet;
	private int randWeapon;
	private GameObject weapon;
	public GameObject prefBullet;
	private Sprite bulletWeapon;
	private int ammoWeapon = 0;
	private float rateWeapon;
	private float distanceWeapon;
	private AudioClip soundWeapon;

	private float tmpRate;
	private bool isShot = true;
	private float timeDrop = 0.5f;
	public bool isend = false;
	int body;
	int head;


	public Text textAmmo;
	public Text textEnd;
		
	// Use this for initialization
	void Start () {
		head = Random.Range (0, 14);
		body = Random.Range (0, 3);

		Head.sprite = listHead [head];
		Body.sprite = listBody [body];
		rg2d = gameObject.GetComponent<Rigidbody2D> ();
		aSrc = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {

		if (isend) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Time.timeScale = 1;
				isend = false;
				Application.LoadLevel(0);
			}
			if (Input.GetKeyDown(KeyCode.Return)) {
				Time.timeScale = 1;
				isend = false;
				Application.LoadLevel(1);
			}
			return;
		}
		if (isWeapon == true) {
			textAmmo.text = "Ammo :" + ammoWeapon;
		}
		else
			textAmmo.text = "";
		walk.SetBool("isWalking", false);
		rg2d.velocity = Vector2.zero;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		rotateHero (mousePosition);

		if (Input.GetKeyDown(KeyCode.Alpha0)){
			head = Random.Range (0, 14);
			body = Random.Range (0, 3);
			
			Head.sprite = listHead [head];
			Body.sprite = listBody [body];
		}
		if ( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			rg2d.velocity += Vector2.up * speed * Time.deltaTime;
			walk.SetBool("isWalking", true);	
		} 
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
			rg2d.velocity += Vector2.down * speed * Time.deltaTime;
			walk.SetBool("isWalking", true);		} 
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			rg2d.velocity += Vector2.left * speed * Time.deltaTime;
			walk.SetBool("isWalking", true);		} 
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			rg2d.velocity += Vector2.right * speed * Time.deltaTime;
			walk.SetBool("isWalking", true);
		}

		if (Input.GetMouseButtonDown (0) && isWeapon == true && isShot && (ammoWeapon > 0 || ammoWeapon == -1)) {
			onShot ();
			isShot = false;
			tmpRate = rateWeapon;
		}
		if (Input.GetMouseButtonDown (1) && isWeapon == true) {

			onDrop ();
		}
		if (!isShot) {
			rateWeapon -= Time.deltaTime;
			if (rateWeapon <= 0) {
				isShot = true;
				rateWeapon = tmpRate;
			}
		}
		if (isDrop) {
			timeDrop -= Time.deltaTime;
			if (timeDrop <= 0) {
				isDrop = false;
				timeDrop = 0.5f;
			} else {
				weapon.transform.Translate (Vector3.right * Time.deltaTime * 2.0f);
				//weapon.transform.Translate (-weapon.transform.right * Time.deltaTime * 2.0f);
			}
		}
	}

	void onShot () {
		aSrc.PlayOneShot (soundWeapon);
		if (ammoWeapon > 0)
			ammoWeapon--;
		prefBullet.GetComponent<SpriteRenderer> ().sprite = bulletWeapon;
		prefBullet.GetComponent<bullet> ().distance = distanceWeapon;
		prefBullet.GetComponent<bullet> ().tag = "Player";
		Instantiate (prefBullet, positionBullet.transform.position, positionBullet.transform.rotation);
	}

	void onDrop () {
		weapon.GetComponent<weapon> ().setAmmoWeapon(ammoWeapon);
		weapon.SetActive (true);
		weapon.transform.RotateAround (transform.position, Vector3.forward, 90f);
		isDrop = true;
		isWeapon = false;
		WeaponSprite.sprite = null;
		weapon.transform.position = new Vector3(positionBullet.transform.position.x, positionBullet.transform.position.y, 0);
		//weapon.transform.Translate (Input.mousePosition * Time.deltaTime * 0.001f);
		//weapon.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0.0001f, 0.0001f), ForceMode2D.Impulse);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "win") {
			Time.timeScale = 0;
			textEnd.text = "Victoire";
			GameObject.Find("endPanel").GetComponent<CanvasGroup>().alpha = 1;
			isend = true;
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.transform.tag == "weapon" && Input.GetMouseButtonDown(0)) {
			if (!isWeapon) {
				isShot = false;
				isWeapon = true;
				weapon = other.gameObject;
				WeaponSprite.sprite = other.gameObject.GetComponent<weapon>().getAttachedWeapon();
				bulletWeapon = other.gameObject.GetComponent<weapon>().getBulletWeapon();
				ammoWeapon = other.gameObject.GetComponent<weapon>().getAmmoWeapon();
				rateWeapon = other.gameObject.GetComponent<weapon>().getRateWeapon();
				distanceWeapon = other.gameObject.GetComponent<weapon>().getDistanceWeapon();
				soundWeapon = other.gameObject.GetComponent<weapon>().getSoundWeapon();
				weapon.SetActive(false);
			}
		}
	}

	public void    rotateHero(Vector3 pToGo)
	{
		Vector3 lookPos = pToGo - transform.position;
		
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}
}

using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {

	
	public Sprite[] listHead;
	public Sprite[] listBody;
	public SpriteRenderer Head;
	public SpriteRenderer Body;
	public SpriteRenderer WeaponSprite;
	public float speed;
	public Animator walk;
	bool hitWeapon = false;

	public Vector3 cherch;
	public bool wlk = false;
	public GameObject player;

	private Rigidbody2D rg2d;

	public Sprite weapon;
	public Sprite bulletWeapon;
	public int ammoWeapon;
	public float rateWeapon;
	public float distanceWeapon;
	public GameObject positionBullet;
	public GameObject prefBullet;
	private bool isDetected = false;
	private float timeDetection = 8.0f;
	int body;
	int head;
	int move;	
	// Use this for initialization
	void Start () {

		head = Random.Range (0, 14);
		body = Random.Range (0, 4);
		
		Head.sprite = listHead [head];
		Body.sprite = listBody [body];
		rg2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		walk.SetBool("isWalking", false);
		if (isDetected == true && timeDetection > 0) {
			timeDetection -= Time.deltaTime;
			rotateHero (player.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 2 * Time.deltaTime);
			walk.SetBool ("isWalking", true);
			rateWeapon -= Time.deltaTime;
			if (rateWeapon <= 0) {
				onShot ();
				rateWeapon = 1.0f;
			}
		} else {
			walk.SetBool ("isWalking", false);
			isDetected = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			head = Random.Range (0, 14);
			body = Random.Range (0, 3);
			
			Head.sprite = listHead [head];
			Body.sprite = listBody [body];
		}

//		if ( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
//			rg2d.velocity += Vector2.up * speed * Time.deltaTime;
//			walk.SetBool("isWalking", true);	
//		} 
//		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
//			rg2d.velocity += Vector2.down * speed * Time.deltaTime;
//			walk.SetBool("isWalking", true);		} 
//		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
//			rg2d.velocity += Vector2.left * speed * Time.deltaTime;
//			walk.SetBool("isWalking", true);		} 
//		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
//			rg2d.velocity += Vector2.right * speed * Time.deltaTime;
//			walk.SetBool("isWalking", true);

		}
	public void	rotateHero(Vector3 pToGo) {
		Vector3 lookPos = pToGo - transform.position;
		
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
//		rg2d.velocity += Vector2. * speed * Time.deltaTime;
	}
	void onShot (){
		prefBullet.GetComponent<SpriteRenderer> ().sprite = bulletWeapon;
		prefBullet.GetComponent<bullet> ().distance = distanceWeapon;
		prefBullet.GetComponent<bullet> ().tag = "enemy";
		Instantiate (prefBullet, positionBullet.transform.position, positionBullet.transform.rotation);
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isDetected = true;
			timeDetection = 8.0f;
		}

	}
//	void OnTriggerEnter2D(Collider2D coll) {
//		Debug.Log ("test");
//		if (coll.gameObject.tag == "Player"){
//			wlk = true;
//			rotateHero (coll.gameObject.transform.position);
//		}
//	}
}

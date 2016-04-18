using UnityEngine;
using System.Collections;

public class playerScript_ex04 : MonoBehaviour {

	public KeyCode selectedJohn;
	public KeyCode selectedClaire;
	public KeyCode selectedThomas;
	public bool isCurrentPlayer;
	public float jumpForce;
	public float speedMove;
	
	private Rigidbody2D rb2D;
	private bool isGrounded;
	private bool hasJumped;
	
	// Use this for initialization
	void Start () {
		isGrounded = true;
		hasJumped = false;
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		rb2D.mass = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		changePlayer ();
		if(!isGrounded && rb2D.velocity.y == 0) {
			isGrounded = true;
		}
	}
	
	void FixedUpdate () {
		if (isCurrentPlayer) {
			rb2D.mass = 1;
			movePlayer ();
		}
		if (hasJumped) {
			rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			isGrounded = false;
			hasJumped = false;
		}
	}
	
	void changePlayer () {
		if (Input.GetKeyDown (selectedJohn))
			checkCurrentPlayer ("John");
		if (Input.GetKeyDown (selectedClaire))
			checkCurrentPlayer ("Claire");
		if (Input.GetKeyDown (selectedThomas))
			checkCurrentPlayer ("Thomas");
	}
	
	void checkCurrentPlayer (string name) {
		if (gameObject.name == name) {
			isCurrentPlayer = true;
		} else {
			isCurrentPlayer = false;
			rb2D.mass = 1000;
		}
	}
	
	void movePlayer () {
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Translate (speedMove * Time.deltaTime, 0 , 0);
		else if (Input.GetKey (KeyCode.LeftArrow))
			transform.Translate (-speedMove * Time.deltaTime, 0 , 0);
		if (Input.GetKeyDown ("space") && isGrounded)
			hasJumped = true;
	}
	
	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Plateform"))
			transform.parent = null;
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Plateform")) {
			transform.parent = col.transform.parent;
		}
		
	}
}

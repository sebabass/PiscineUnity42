using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class bullet : MonoBehaviour {

	Vector3 mousePosition;
	public float distance;
	[HideInInspector]public string tag;
	private RaycastHit2D hit;
	private bool isEnd = false;

	// Use this for initialization
	void Start () {
		//mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//hit = Physics2D.Raycast (transform.position, mousePosition + transform.position, distance);
		//transform.Rotate (0, 0, 180);
		transform.RotateAround (transform.position, Vector3.forward, 90f);
	}
	
	// Update is called once per frame
	void Update () {
		distance -= Time.deltaTime;
		if (distance <= 0)
			GameObject.Destroy(gameObject);
		transform.Translate (Vector3.left * Time.deltaTime * 15f);
	}

	public void    rotateHero(Vector3 pToGo)
	{
		Vector3 lookPos = pToGo - transform.position;
		
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		Debug.DrawLine (transform.position, mousePosition);
	}

	public void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag != tag && coll.transform.tag != "bullet")
			GameObject.Destroy(gameObject);
		if (tag == "enemy" && coll.transform.tag == "Player") {
			Time.timeScale = 0;
			GameObject.Find ("textEnd").GetComponent<Text>().text = "Looser";
			GameObject.Find("endPanel").GetComponent<CanvasGroup>().alpha = 1;
			coll.gameObject.GetComponent<player>().isend = true;
			isEnd = true;
		}
		if (tag == "Player" && coll.transform.tag == "enemy") {
			GameObject.Destroy (coll.gameObject);
			gameManager.gm.removeEnemy();
		}
	}

}

using UnityEngine;
using System.Collections;

public class switch_ex04 : MonoBehaviour {
	
	public GameObject block;
	public bool isOpen;
	public bool isDestroy;
	public bool isChangeColor;

	public Color colorBlock;
	public bool isThomas;
	public bool isJohn;
	public bool isClaire;

	private SpriteRenderer sprtRenderer;

	// Use this for initialization
	void Start () {
		sprtRenderer = block.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (isChangeColor) {
				changeColor();
			}
			else if (isDestroy)
				GameObject.Destroy(block);
			else if (isOpen) {
				Vector3 position = block.transform.position;
				position.y += 2;
				block.transform.position = position;
			}
			GameObject.Destroy(gameObject);
		}
	}

	void changeColor () {

		sprtRenderer.color = colorBlock;
		if (isThomas)
			block.gameObject.layer = 9;
		else if (isJohn)
			block.gameObject.layer = 10;
		else if (isClaire)
			block.gameObject.layer = 8;
	}
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class dragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

	public gameManager gamemanager;
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}
	
	public void OnDrag(PointerEventData data)
	{
		if (gamemanager.towerPrefabs [int.Parse (itemBeingDragged.name [itemBeingDragged.name.Length - 1].ToString ())].energy <= gamemanager.playerEnergy) {
			transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}
		else
			itemBeingDragged.transform.GetChild (0).GetComponent<Image> ().color = Color.red;
	}
	
	
	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged.transform.GetChild (0).GetComponent<Image>().color = Color.white;
		if (gamemanager.towerPrefabs[int.Parse (itemBeingDragged.name [itemBeingDragged.name.Length - 1].ToString ())].energy <= gamemanager.playerEnergy) {
			
			RaycastHit2D hit = Physics2D.Raycast( itemBeingDragged.transform.position, Vector2.zero );
			if (hit.collider != null && hit.collider.tag == "empty"){
				
				GameObject.Instantiate(gamemanager.towerPrefabs[int.Parse (itemBeingDragged.name [itemBeingDragged.name.Length - 1].ToString ())], transform.position, Quaternion.identity);
				gamemanager.playerEnergy -= gamemanager.towerPrefabs[int.Parse (itemBeingDragged.name [itemBeingDragged.name.Length - 1].ToString ())].energy;
			}
		}
		itemBeingDragged.transform.position = startPosition;
		itemBeingDragged = null;
	}
}

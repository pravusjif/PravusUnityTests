using UnityEngine;
using System.Collections;

public class DraggableObject : MonoBehaviour {
	public bool draggable = true;
	float originalGravityScale;
	Vector3 curPosition;
	Vector3 scanPos;
	Vector3 curScreenPoint;
	Vector3 screenPoint;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		if(rigidbody2D && rigidbody2D.gravityScale > 0)
			originalGravityScale = rigidbody2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		/*if(Input.touchCount > 0){
			GUI.Label(new Rect(10, 10, 100, 20), Input.GetTouch(0).deltaPosition.ToString());
		}
		else {
			GUI.Label(new Rect(10, 10, 400, 20), Input.mousePosition.ToString());
		}*/
	}

	protected virtual void OnMouseDown() {
		if(rigidbody2D && rigidbody2D.gravityScale > 0)
			rigidbody2D.gravityScale = 0;

		scanPos = gameObject.transform.position;
		screenPoint = Camera.main.WorldToScreenPoint(scanPos);
		
		if(Input.touchCount > 0){
			offset = scanPos - Camera.main.ScreenToWorldPoint(
				new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z));
		}
		else {
			offset = scanPos - Camera.main.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}

	void OnMouseDrag(){
		if(Input.touchCount > 0){		
			curScreenPoint = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z);
		}
		else {
			curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		}


		curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		if(draggable)
			transform.position = curPosition;
	}

	protected virtual void OnMouseUp(){
		if(rigidbody2D)
			rigidbody2D.gravityScale = originalGravityScale;
	}
}

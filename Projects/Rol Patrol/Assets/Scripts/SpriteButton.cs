using UnityEngine;
using System.Collections;

public class SpriteButton : MonoBehaviour {
	private Vector3 originalSize;

	// Use this for initialization
	protected virtual void Start () {
		originalSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver() {
		transform.localScale = new Vector2(originalSize.x + originalSize.x * 0.1f, originalSize.y + originalSize.y * 0.1f);
	}

	protected virtual void OnMouseDown(){
		transform.localScale = originalSize;
	}

	void OnMouseExit(){
		transform.localScale = originalSize;
	}
}

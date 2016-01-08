using UnityEngine;
using System.Collections;

public class TouchScrollableBG : MonoBehaviour {
	
	private Vector3 pos;
	public float scrollingSpeed = 1.5f;
	private Material mat;
	private float horizontalMouseValue;
	private Vector2 textureOffset;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer>().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			horizontalMouseValue = scrollingSpeed * Input.GetAxis("Mouse X");
			if(horizontalMouseValue < 0){
				textureOffset = mat.mainTextureOffset;
				textureOffset.x += Mathf.Abs(horizontalMouseValue * scrollingSpeed);
				mat.mainTextureOffset = textureOffset;
			}
		}
	}
}

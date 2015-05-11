using UnityEngine;
using System.Collections;

public class ScrollableBG : MonoBehaviour {
	
	private Vector3 pos;
	public float scrollingSpeed = 1.5f;
	private Material mat;
	
	// Use this for initialization
	void Start () {
		
		mat = renderer.sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 to = mat.mainTextureOffset;
		to.x = Mathf.Repeat( to.x + Time.deltaTime * scrollingSpeed,1);
		mat.mainTextureOffset = to;
	}
}

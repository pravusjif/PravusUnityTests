using UnityEngine;
using System.Collections;

public class TouchScrollableBG : MonoBehaviour {
	
	private Vector3 pos;
	public float scrollingValue = 1f;
	public bool acceleration = true;
	public float accelerationValue = 0.9f;
	public float accelerationScrollingValue = 1f;
	private bool accelerationInMotion = false;
	private Material mat;
	private float horizontalMouseValue;
	private Vector2 textureOffset;
	private float lastMouseClickTime = 0;
	private float mouseMovementSpeed = 0;

	// Use this for initialization
	void Start () {
		mat = renderer.sharedMaterial;
		accelerationScrollingValue = scrollingValue;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			lastMouseClickTime = Time.timeSinceLevelLoad;
		}

		if(Input.GetMouseButton(0)){
			horizontalMouseValue = Input.GetAxis("Mouse X");

			if(horizontalMouseValue < 0){
				textureOffset = mat.mainTextureOffset;
				textureOffset.x += Mathf.Abs(horizontalMouseValue * scrollingValue * Time.deltaTime);
				mat.mainTextureOffset = textureOffset;

				if(acceleration){
					accelerationInMotion = true;
				}
			}
		}
		else if(acceleration && accelerationInMotion){
			if(Input.GetMouseButtonUp(0)){
				mouseMovementSpeed = Mathf.Abs(horizontalMouseValue / (Time.timeSinceLevelLoad - lastMouseClickTime));
				accelerationScrollingValue = mouseMovementSpeed * Time.deltaTime * 3;
			}

			if(accelerationScrollingValue > 0){
				//calculate according to acceleration
				accelerationScrollingValue -= Time.deltaTime * accelerationValue;
				
				textureOffset = mat.mainTextureOffset;
				textureOffset.x += Mathf.Abs(accelerationScrollingValue * Time.deltaTime);
				mat.mainTextureOffset = textureOffset;
			}
			else{
				accelerationScrollingValue = scrollingValue;
				accelerationInMotion = false;
			}
		}
	}
}

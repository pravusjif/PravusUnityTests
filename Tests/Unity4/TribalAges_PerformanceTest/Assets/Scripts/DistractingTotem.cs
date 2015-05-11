using UnityEngine;
using System.Collections;

public class DistractingTotem : MonoBehaviour {
	
	public MainTotem mainTotem = null;
	public AudioSource distractingTotemSoundLoop = null;
	
	private float radius;
	private Vector3 distanceToCheck = Vector3.zero;
	private Vector3 positionToCheck = Vector3.zero;
	private Vector3 detectedDevicePosition = Vector3.zero;
	private float minDist;
	private float minDistSqr;
	private bool touchDetected = false;
	
	// Use this for initialization
	void Start () {
		radius = transform.localScale.x / 2;
		mainTotem = (MainTotem) GameObject.FindObjectOfType(typeof(MainTotem));
	}
	
	// Update is called once per frame
	void Update () {
		DistractMainTotem();
		PlayTotemMusic();
	}
	
	public bool UserTouchesThisTotem() {
		touchDetected = (Input.touchCount > 0);
		
		minDist = 1 + radius;
        minDistSqr = Mathf.Pow(minDist, 2);
		
		if (touchDetected) {
			detectedDevicePosition = Input.GetTouch(0).position;
		}
		else {
			//return false;
			detectedDevicePosition = Input.mousePosition;
		}
		
		positionToCheck = Camera.mainCamera.ScreenToWorldPoint(detectedDevicePosition);
        distanceToCheck = transform.position - positionToCheck;
		
		return (distanceToCheck.sqrMagnitude < minDistSqr);
	}
	
	private void DistractMainTotem() {
		if(mainTotem) {
			if(UserTouchesThisTotem()) {				
				mainTotem.distractingPos = transform.position;
				mainTotem.distractingTotemIID = gameObject.GetInstanceID();
			}
			else if(mainTotem.distractingTotemIID == gameObject.GetInstanceID()) {				
				mainTotem.distractingTotemIID = -1;
				mainTotem.distractingPos = Vector3.zero;
			}
		}		
	}
	
	void PlayTotemMusic() {
		if(distractingTotemSoundLoop){
			if(UserTouchesThisTotem()){
				distractingTotemSoundLoop.volume = 1;
			}
			else{
				distractingTotemSoundLoop.volume = 0;
			}
		}
	}
	
	/*void OnGUI() {
		GUI.Label(new Rect(0, 0, 150, 30), "pos: " + detectedDevicePosition.ToString());
		GUI.Label(new Rect(0, 31, 150, 30), "deltaPos: " + Input.GetTouch(0).deltaPosition.ToString());
		GUI.Label(new Rect(0, 61, 150, 30), "touch: " + touchDetected.ToString());
		GUI.Label(new Rect(0, 91, 150, 30), "touchCount: " + Input.touchCount.ToString());
		GUI.Label(new Rect(0, 121, 150, 30), "mousePos: " + Input.mousePosition.ToString());
		GUI.Label(new Rect(0, 151, 150, 100), "joysticks: " + Input.GetJoystickNames());
	}*/
}

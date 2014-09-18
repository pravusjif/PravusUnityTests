using UnityEngine;
using System.Collections;

public class CamPhotoPrompter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			EtceteraAndroid.promptToTakePhoto( 512, 512, "photo.jpg" );
		}	
	}
}

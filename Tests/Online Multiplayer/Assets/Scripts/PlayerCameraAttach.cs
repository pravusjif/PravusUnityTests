using UnityEngine;
using System.Collections;

public class PlayerCameraAttach : MonoBehaviour {
	void Start () {
		if(networkView.isMine){
			Camera.main.GetComponent<CameraFollow>().objectToFollow = this.transform;
		}
		else
			enabled = false;
	}
}

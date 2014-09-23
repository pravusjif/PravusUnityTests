using UnityEngine;
using System.Collections;

public class PlayerCameraAttach : MonoBehaviour {
	public Transform cameraPosition = null;

	void Start () {
		if(networkView.isMine && cameraPosition){
			Camera.main.GetComponent<CameraFollow>().cameraPosition = cameraPosition;
		}
		else
			enabled = false;
	}
}

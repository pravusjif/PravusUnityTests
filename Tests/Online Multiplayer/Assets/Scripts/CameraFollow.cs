using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform cameraPosition = null;

	void Update () {
		if(cameraPosition){
			transform.position = cameraPosition.position;
			transform.rotation = cameraPosition.rotation;
		}
	}
}

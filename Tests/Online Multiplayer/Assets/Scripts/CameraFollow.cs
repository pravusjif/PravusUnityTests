using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform objectToFollow = null;
	Vector3 auxiliarVector;
	bool startedFollowing = false;

	void Update () {
		if(objectToFollow && !startedFollowing){
			auxiliarVector = transform.position;

			auxiliarVector.x = objectToFollow.position.x;
			auxiliarVector.y = objectToFollow.position.y + 1.8f;
			auxiliarVector.z = objectToFollow.position.z - 4;

			transform.position = auxiliarVector;

			transform.parent = objectToFollow;

			startedFollowing = true;
		}
	}
}

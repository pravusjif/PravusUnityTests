using UnityEngine;
using System.Collections;

public class LevelBackground : MonoBehaviour {
	public float zRotationSpeed = 2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.AngleAxis(-zRotationSpeed * Time.deltaTime, Vector3.forward);
	}
}

using UnityEngine;
using System.Collections;

public class Melody : MonoBehaviour {
	private Vector3 pos = Vector3.zero;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = Camera.mainCamera.transform.position;
		transform.position = pos;
	}
}

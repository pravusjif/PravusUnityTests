using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
	public Transform startingObject = null;
	public Transform endingObject = null;
	LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetPosition(0, startingObject.position);
		lineRenderer.SetPosition(1, endingObject.position);
	}
}

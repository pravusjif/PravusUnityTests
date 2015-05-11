using UnityEngine;
using System.Collections;

public class LevelLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) // Android's "Back" button
		{
			Application.Quit();
		}
	}
}

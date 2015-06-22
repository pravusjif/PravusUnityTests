using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	public string loadLevelWithBackButton = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(loadLevelWithBackButton == "")
				Application.Quit();
			else
				Application.LoadLevel(loadLevelWithBackButton);
		}
	}
}

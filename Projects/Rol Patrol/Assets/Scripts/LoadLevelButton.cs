using UnityEngine;
using System.Collections;

public class LoadLevelButton : SpriteButton {
	public string levelToLoad = "";

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp(){
		if(levelToLoad != "")
			Application.LoadLevel(levelToLoad);
	}
}

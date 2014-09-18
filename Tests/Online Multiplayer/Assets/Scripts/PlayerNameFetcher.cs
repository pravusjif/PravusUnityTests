using UnityEngine;
using System.Collections;

public class PlayerNameFetcher : MonoBehaviour {
	public string playerName = "Player Name";
	float buttonXPos = Screen.width * 0.05f;
	float buttonYPos = Screen.height * 0.05f;
	float buttonWidth = Screen.width * 0.1f;
	float buttonHeight = Screen.width * 0.03f;

	void Update () {
		transform.GetChild(0).GetComponent<TextMesh>().text = playerName;
	}

	void OnGUI(){
		if(networkView.isMine)
			playerName = GUI.TextField(new Rect(buttonXPos, buttonYPos, buttonWidth, buttonHeight), playerName);		
	}
}

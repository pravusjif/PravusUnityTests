using UnityEngine;
using System.Collections;

public class GameLogic_MainScene : GameLogic {
	public bool maxiButtonTouched = false;
	public bool ushiButtonTouched = false;



	public GameObject maxiButton;
	public GameObject ushiButton;

	// Use this for initialization
	void Start () {
		if(!maxiButton)
			maxiButton = GameObject.Find("Maxi Button");

		if(!ushiButton)
			ushiButton = GameObject.Find("Ushi Button");
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

		if(Input.touchCount > 0){
			foreach(Touch tch in Input.touches){
				if(maxiButton.collider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tch.position))){
					maxiButtonTouched = true;
				}
				else if(ushiButton.collider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tch.position))){
					ushiButtonTouched = true;
				}
			}
		}

		if(maxiButtonTouched && ushiButtonTouched){
			// play scream sound
			if(audio)
				audio.Play();

			// load bonus level
			Application.LoadLevel("BonusLevel");
		}
		else{
			maxiButtonTouched = false;
			ushiButtonTouched = false;
		}
	}
}

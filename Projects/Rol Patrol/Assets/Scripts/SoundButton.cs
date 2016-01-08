using UnityEngine;
using System.Collections;

public class SoundButton : SpriteButton {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnMouseDown(){
		base.OnMouseDown();

		if(GetComponent<AudioSource>()){
			GetComponent<AudioSource>().Play();
		}
	}
}

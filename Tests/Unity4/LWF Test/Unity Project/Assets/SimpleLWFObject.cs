using UnityEngine;
using System.Collections;

public class SimpleLWFObject : LWFObject  {
	public string texturePrefix;
	
	// Use this for initialization
	void Start () {
		Load(lwfName, texturePrefix);
		PlayAnimation("idle");
	}
	
	public void PlayAnimation(string name) {
		
		Debug.Log("Play LWF Animation: " + name);
		
		switch(name) {
		case "idle":
			//PlayMovie("idle");
			GotoAndPlayMovie("idle", "idle", false);
			SetAlphaMovie("idle",1f);
			break;
			
		case "walk_left":
			StopMovie("guy_right");
			PlayMovie("guy_left");
			SetAlphaMovie("guy_left",1f);
			SetAlphaMovie("guy_right",0);
			//SetVisibleMovie("guy_left", true);
			//SetVisibleMovie("guy_right", false);
			break;
			
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class MonkeyTotem : Totem {
	// Use this for initialization
	protected override void Start () {
		base.Start();
		uvW = 0.125f;
		uvH = 0.125f;
	}
	
	// Update is called once per frame
	protected override void Update () {
	
	}
	
	protected override void DrawAnimation() {
		// Put sprite on the client object
		if(renderer)
			renderer.enabled = false;
		
		totemSprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0.625f, 0.375f), new Vector2(uvW, uvH), Vector3.zero, false);
		
		// Set up Animations
		//CreateAnimation("monkeyIdle", new Vector2(uvX, uvY), new Vector2(uvW, uvH), 4, -1, true, 5);
		
		// Play Animation
		totemSprite.AddAnimation(CreateAnimation("monkeyIdle", new Vector2(0.625f, 0.375f), new Vector2(uvW, uvH), 4, -1, true, 5));
		totemSprite.PlayAnim("monkeyIdle");
	}
}

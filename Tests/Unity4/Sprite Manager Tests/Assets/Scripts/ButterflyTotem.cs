using UnityEngine;
using System.Collections;

public class ButterflyTotem : Totem {
	
	// Use this for initialization
	protected override void Start () {
		base.Start();
		uvW = 0.125f;
		uvH = 0.125f;
	}
	
	// Update is called once per frame
	protected override void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			//totemSprite.PauseAnim();
			totemSprite.PlayAnim("butterflyTouch");
			totemSprite.SetAnimCompleteDelegate(new Sprite.AnimCompleteDelegate(resetAnim));
		}
	}
	
	protected override void DrawAnimation() {
		// Put sprite on the client object
		if(renderer)
			renderer.enabled = false;
		
		totemSprite = spriteManager.AddSprite(this.gameObject, 1f, 1f, new Vector2(0.625f, 0.375f), new Vector2(uvW, uvH), Vector3.zero, false);
		
		// Set up Animations
		//CreateAnimation("butterflyIdle", new Vector2(uvX, uvY), new Vector2(uvW, uvH), 4, -1, true, 5);
		
		// Play Animation
		totemSprite.AddAnimation(CreateAnimation("butterflyIdle", new Vector2(6*uvW, 4*uvH), new Vector2(uvW, uvH), 4, -1, true, 5));
		totemSprite.AddAnimation(CreateAnimation("butterflyTouch", new Vector2(2*uvW, 3*uvH), new Vector2(uvW, uvH), 3, 0, false, 5));
		totemSprite.PlayAnim("butterflyIdle");
	}
	
	public void resetAnim() {
		
		totemSprite.PlayAnim("butterflyIdle");
		totemSprite.UnpauseAnim();
	}
}

using UnityEngine;
using System.Collections;

public class SceneSprites : MonoBehaviour {
	public SpriteManager spriteManager = null;
	public float framerate = 24;	
	
	// Use this for initialization
	void Start () {
		DrawAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DrawAnimation() {
		// Put sprite on the client object
		GameObject totem = GameObject.Find("TotemMono");
		totem.renderer.enabled = false;
		Sprite totemSprite = spriteManager.AddSprite(totem, 1f, 1f, new Vector2(0, 0.5f), new Vector2(0.5f, 0.5f), Vector3.zero, false);
		
		// Set up animation
		UVAnimation anim = new UVAnimation();
		anim.name = "animation1";
		anim.loopCycles = -1;
		anim.framerate = framerate;
		
		anim.BuildUVAnim(new Vector2(0, 0.5f), new Vector2(0.5f, 0.5f), 2, 2, 4, framerate);
		
		// Prepare sprite
		totemSprite.AddAnimation(anim);
		totemSprite.PlayAnim("animation1");
	}
}

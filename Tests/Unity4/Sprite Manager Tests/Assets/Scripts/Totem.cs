using UnityEngine;
using System.Collections;

public class Totem : MonoBehaviour {
	protected static SpriteManager spriteManager = null;
	protected Sprite totemSprite;
	
	// the dimensions of the sprite in the sprite texture
    public float uvW = 0.25f;
    public float uvH = 0.25f;
	
	// anim values
	public int spriteSheetCols = 8;
	public int spriteSheetRows = 8;
	
	// Use this for initialization
	protected virtual void Start () {
		if (spriteManager == null)
        {
            spriteManager = (SpriteManager)Component.FindObjectOfType(typeof(SpriteManager));
        }
		
		DrawAnimation();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	
	protected virtual void DrawAnimation() {

	}
	
	protected UVAnimation CreateAnimation(string animName, Vector2 startUVPos, Vector2 UVSize, int animCells, int loopCycles, bool pingPongAnim, float framerate){
		UVAnimation anim = new UVAnimation();
		anim.name = animName;
		anim.loopCycles = loopCycles;
		anim.framerate = framerate;
		if(pingPongAnim)
			anim.loopReverse = true;
		
		anim.BuildUVAnim(startUVPos, UVSize, spriteSheetCols, spriteSheetRows, animCells, framerate);		
		return anim;
	}
}

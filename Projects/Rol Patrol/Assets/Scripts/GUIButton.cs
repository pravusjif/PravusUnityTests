using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour {
	public Texture onClickTexture;
	public bool resizeOnClick = false;
	public Vector3 resizeOnClickScale = Vector3.zero;
	public bool active = true;
	public GameObject animationObject = null;
	public string animationName = "";
	public ParticleSystem particleSystem = null;
	public bool particleSystemStart = false;
	protected GUITexture internalGUITexture = null;	
	protected Texture originalTex;
	protected Vector3 originalScale;
	//protected bool pressed = false;
	
	
	// Use this for initialization
	protected virtual void Start () {
		internalGUITexture = (GUITexture)GetComponent<GUITexture>();

		if(internalGUITexture)
			originalTex = internalGUITexture.texture;

		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(active){
			if(internalGUITexture && internalGUITexture.HitTest(Input.mousePosition)){
				if(Input.GetMouseButton(0)){
					if(onClickTexture) {
						internalGUITexture.texture = onClickTexture;
					}
					
					if(resizeOnClick){
						transform.localScale = resizeOnClickScale;
					}
					
					if(particleSystem){
						if(particleSystemStart)
							particleSystem.Emit(1000);
						else
							particleSystem.Stop();
					}
						
					
					if(animationObject && animationName != "")
						animationObject.animation.Play(animationName);
				}
				else {
					if(onClickTexture)
						internalGUITexture.texture = originalTex;
					
					transform.localScale = originalScale;
				}
			}
			else if(resizeOnClick)
				transform.localScale = originalScale;			
		}
	}

	protected virtual void OnMouseDown(){
		if(audio){
			audio.Play();
		}
	}
}

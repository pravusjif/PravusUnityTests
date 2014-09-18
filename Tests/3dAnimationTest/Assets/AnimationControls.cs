using UnityEngine;
using System.Collections;

public class AnimationControls : MonoBehaviour {
	
	public Animation animation = null;
	
	// Use this for initialization
	void Start () {
		if(animation) {
			animation.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

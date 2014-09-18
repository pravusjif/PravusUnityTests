using UnityEngine;
using System.Collections;

public class Mage : MonoBehaviour {
	Animator animator = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && animator){
			Debug.Log("special power called");
			animator.Play("specialPower");
		}
	}
}

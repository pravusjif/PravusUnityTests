using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int speed = 5;
	public float gravity = 5;
	CharacterController controller;

	void Awake(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		if(networkView.isMine)
			controller.Move(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, -gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
		else
			enabled = false;
	}
}

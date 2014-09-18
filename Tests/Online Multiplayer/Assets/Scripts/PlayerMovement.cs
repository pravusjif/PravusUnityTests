using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int movementSpeed = 5;
	public int rotationSpeed = 50;
	public int jumpPower = 5;
	public float jumpMaxHeight = 15;
	public float gravity = 5;
	CharacterController controller;
	Vector3 auxiliarVector;
	bool jumping = false;
	float beforeJumpYPos;
	Vector3 auxiliarEulerAngles;
	Quaternion auxiliarRotation;

	void Awake(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		if(networkView.isMine){
			MovePlayer();
		}
		else
			enabled = false;
	}

	void MovePlayer(){		
		auxiliarVector = transform.position;

		// Rotate
		if(Input.GetAxis("Horizontal") != 0.0f)
		{
			this.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, Vector3.up); 
		}

		// Advance
		if(Input.GetAxis("Vertical") != 0){
			auxiliarVector += transform.forward * (Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
		}

		if(!jumping){
			if(Input.GetKeyDown(KeyCode.Space)){
				jumping = true;
				beforeJumpYPos = auxiliarVector.y;

				auxiliarVector.y += jumpPower * Time.deltaTime;
			}
		}
		else {
			auxiliarVector.y += jumpPower * Time.deltaTime;

			if(Mathf.Abs(auxiliarVector.y - beforeJumpYPos) > jumpMaxHeight){
				//auxiliarVector.y = beforeJumpYPos + jumpMaxHeight;

				jumping = false;
			}
		}
		
		transform.position = auxiliarVector;
	}
}

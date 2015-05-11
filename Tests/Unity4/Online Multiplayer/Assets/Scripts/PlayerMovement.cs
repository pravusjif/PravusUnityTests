using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int movementSpeed = 5;
	public int mouseMovementSpeed = 5;
	public int rotationSpeed = 50;
	public int jumpPower = 7;
	CharacterController controller;
	Vector3 auxiliarVector;
	Vector3 auxiliarEulerAngles;
	Quaternion auxiliarRotation;
	public Vector3 moveTargetPosition;

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

		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
		}
		
		transform.position = auxiliarVector;

		if(Input.GetMouseButtonDown(0)){
			GetMoveTargetPosition();
			MoveTowardsTargetPosition();
		}
	}

	void GetMoveTargetPosition(){
		auxiliarVector = Input.mousePosition;
		auxiliarVector.z = 20;

		moveTargetPosition = Camera.main.ScreenToWorldPoint(auxiliarVector);
	}

	void MoveTowardsTargetPosition(){
		rigidbody.velocity = Vector3.zero;

		Vector3 forceTowardsPosition = moveTargetPosition - transform.position;
		//forceTowardsPosition = forceTowardsPosition.normalized *  mouseMovementSpeed;
		forceTowardsPosition.y = 0;

		rigidbody.AddForce(forceTowardsPosition, ForceMode.VelocityChange);
	}
}

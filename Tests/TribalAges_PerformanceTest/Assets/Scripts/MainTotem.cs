using UnityEngine;
using System.Collections;

public class MainTotem : MonoBehaviour {
	public Vector3 distractingPos = Vector3.zero;
	public int distractingTotemIID = -1;
	public float speed = 100;
	private CharacterController characterController;
	private Vector3 moveTowardsResult;
	private FollowingCamera followingCamera;
	private FinalTotem finalTotem = null;
	
	void Awake() {
		followingCamera = (FollowingCamera)(Camera.main.GetComponent("FollowingCamera"));
		followingCamera.mainTotem = this;		
	}
	
	// Use this for initialization
	void Start () {
		finalTotem = (FinalTotem) GameObject.FindObjectOfType(typeof (FinalTotem));
		characterController = (CharacterController)GetComponent("CharacterController");
	}
	
	// Update is called once per frame
	void Update () {
		if (distractingPos != Vector3.zero) {
			moveTowardsResult = Vector3.MoveTowards(transform.position, distractingPos, speed * Time.deltaTime);
		}
		else {
			moveTowardsResult = Vector3.MoveTowards(transform.position, finalTotem.transform.position, speed * Time.deltaTime);
		}
		
		characterController.Move(moveTowardsResult - transform.position);
	}
}

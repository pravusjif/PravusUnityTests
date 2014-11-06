using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class MainCharacter : MonoBehaviour {

	[System.NonSerialized]					
	public float lookWeight;

	public float animSpeed = 1.0f;				// a public setting for overall animator animation speed
	public float lookSmoother = 3f;				// a smoothing setting for camera motion
	public bool useCurves;						// a setting for teaching purposes to show use of curves

	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private CapsuleCollider col;					// a reference to the capsule collider of the character

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int walkState = Animator.StringToHash("Base Layer.Walking");			// these integers are references to our animator's states
	static int jumpState = Animator.StringToHash("Base Layer.Jump");			// and are used to check state for various actions to occur

	// -----

	private float strafeMovement = -1;
	private float forwardMovement = -1;

	public bool isMoving;
	private Vector3 previousPosition = Vector3.zero;
	private Vector3 pos = Vector3.zero;
	
	public float movementSpeed = 1;

	// -----------------

	void Start () {
		this.anim = GetComponent<Animator>();
		this.col = GetComponent<CapsuleCollider>();
	}

	void FixedUpdate() {
		this.previousPosition = this.transform.position;


		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		if (currentBaseState.nameHash == walkState && Input.GetButtonDown("Jump")) {
			anim.SetBool ("Jump", true);
		} else if(currentBaseState.nameHash == jumpState){
			if(!anim.IsInTransition(0)){
				anim.SetBool("Jump", false);
			}
		}

		anim.SetFloat("Speed", ver); 		// "Speed" es el nombre del param en Mecanim
		anim.SetFloat("Direction", hor);
		anim.speed = animSpeed;
	}

	void Update () {

	}

	// -----------------

	public bool getMovingState() {
		return this.previousPosition != this.transform.position;
	}
}

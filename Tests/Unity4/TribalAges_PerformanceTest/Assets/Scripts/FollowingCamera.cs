using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour {
	public MainTotem mainTotem = null;
	private Vector3 position;
	
	// Use this for initialization
	void Start () {
		position = transform.position;
		position.x = mainTotem.transform.position.x;
		position.y = mainTotem.transform.position.y;
		
		transform.position = position;	
	}
	
	// Update is called once per frame
	void Update () {
		if(mainTotem) {
			position.x = mainTotem.transform.position.x;
			position.y = mainTotem.transform.position.y;
			
			transform.position = position;			
		}
	}
}

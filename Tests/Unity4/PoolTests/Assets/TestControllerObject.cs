using UnityEngine;
using System.Collections;

public class TestControllerObject : MonoBehaviour {

	public Pool mainPool;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
		{
			mainPool.Create();
		}
	}
}

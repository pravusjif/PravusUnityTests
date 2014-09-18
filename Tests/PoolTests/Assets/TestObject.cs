using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {
	
	public Pool parentPool = null;
	
	// Use this for initialization
	void Start () {
		PoolCreatedObject pco = null;
		if(pco = GetComponent<PoolCreatedObject>())
		{
			parentPool = pco.creatorPool;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
		{
			parentPool.Recycle(this.gameObject);
		}
	}
}

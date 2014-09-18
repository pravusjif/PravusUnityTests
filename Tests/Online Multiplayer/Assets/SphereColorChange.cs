using UnityEngine;
using System.Collections;

public class SphereColorChange : MonoBehaviour {

	void OnTriggerEnter(){
		renderer.material.color = Color.green;
	}
}

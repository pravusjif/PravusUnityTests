using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		//iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("testPath"), "time", 5));
		iTween.MoveTo(gameObject, iTween.Hash(
			"path", iTweenPath.GetPath("testPath"),
			"time", 5,
			"easetype", iTween.EaseType.easeInOutSine,
			"orientToPath", true
			,"axis", "x"
			));
	}
	
	// Update is called once per frame
	void Update () {

	}
}

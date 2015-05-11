using UnityEngine;
using System.Collections;

public class GravityManager : MonoBehaviour {
	public bool showGyroInfo = false;
	Gyroscope gyro = null;
	bool gyroEnabled = false;

	// Use this for initialization
	void Start () {
		gyro = Input.gyro;
		gyro.enabled = true;
		gyroEnabled = (gyro.attitude != null);
	}
	
	// Update is called once per frame
	void Update () {
		if(gyroEnabled){
			Physics2D.gravity = gyro.gravity;
		}
	}

	void OnGUI(){
		if(showGyroInfo){
			if(gyro.attitude != null){
				GUI.Label(new Rect(10, 10, 100, 20), gyro.attitude.ToString());
			}

			if(gyro.enabled != null){
				GUI.Label(new Rect(10, 25, 100, 20), gyro.enabled.ToString());
			}

			if(gyro.gravity != null){
				GUI.Label(new Rect(10, 40, 100, 20), gyro.gravity.ToString());
			}

			if(gyro.rotationRate != null){
				GUI.Label(new Rect(10, 55, 100, 20), gyro.rotationRate.ToString());
			}

			if(gyro.rotationRateUnbiased != null){
				GUI.Label(new Rect(10, 70, 100, 20), gyro.rotationRateUnbiased.ToString());
			}

			GUI.Label(new Rect(10, 85, 100, 20), gyro.ToString());
		}
	}
}

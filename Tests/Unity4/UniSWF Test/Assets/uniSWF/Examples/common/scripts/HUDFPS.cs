using UnityEngine;
using System.Collections;

public class HUDFPS : MonoBehaviour
{
	public float updateInterval = 0.5F;	 
	private float accum = 0;
	private int   frames = 0;
	private float timeleft;
	private string s = " ";
	 
	void Start()
	{	 
	    timeleft = updateInterval;  
	}
	 
	void Update()
	{
	    timeleft -= Time.deltaTime;
	    accum += Time.timeScale / Time.deltaTime;
	    ++frames;

	    if( timeleft <= 0.0 ) {
		    float fps = accum / frames;
		    string format = fps.ToString() + " FPS";
		   	s = format;
		
	        timeleft = updateInterval;
	        accum = 0.0F;
	        frames = 0;
	    }
			
	}
	
	void OnGUI() {
		GUI.TextField ( new Rect(0,Screen.height-20,100,20), s );
	}
		
}
	

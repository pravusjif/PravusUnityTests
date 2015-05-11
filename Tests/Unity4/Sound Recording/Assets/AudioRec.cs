using UnityEngine;
using System.Collections;

public class AudioRec : MonoBehaviour {
	AudioClip myAudioClip; 
	AudioSource audioSource;
    int minFreq = 0;
	int maxFreq = 0;	
	
	void Start() {
		/*string[] devs = Microphone.devices;

        for (int i = 0; i < devs.Length; i++)
        {
                Microphone.GetDeviceCaps(devs[i], out minFreq, out maxFreq);
                Debug.Log(i + ": " + devs[i] + " "+minFreq+":"+maxFreq);
        }
		
		audioSource = GetComponent<AudioSource>();*/
		audio.clip = Microphone.Start ( null, false, 10, 44100 );
		audio.Play();
	}
	
	void Update () {
		
	}
 
	void OnGUI() {
		/*GUI.Button(new Rect(10,10,60,50), minFreq.ToString());
		GUI.Button(new Rect(10,70,60,50), maxFreq.ToString());*/
		
		
	    /*if (GUI.Button(new Rect(10,10,60,50),"Record")) { 
	    	audio.clip = Microphone.Start ( null, false, 10, 44100 );
			//audio.Play();
		}*/
		
		if (GUI.Button(new Rect(10,70,60,50),"Save")) {
			Microphone.End(null);
		    SavWav.Save("myfile", audio.clip);
		
		    //audio.Play();
		}
	}
}

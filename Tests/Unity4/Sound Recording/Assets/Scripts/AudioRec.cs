using UnityEngine;
using EricOulashin;
using System.Collections;

public class AudioRec : MonoBehaviour {
	public bool recordOnStart = true;
	public int secondsToRecord = 10;
	AudioClip myAudioClip;
	
	void Start() {
		if(recordOnStart) {
			audio.clip = Microphone.Start ( null, false, secondsToRecord, 44100 );
			audio.Play();
		}
	}
	
	void Update () {
		
	}
 
	void OnGUI() {		
		if (GUI.Button(new Rect(10,70,120,50),"Stop And Save")) {
			Microphone.End(null);
		    SavWav.Save("Microphone", audio.clip);
		
		    //audio.Play();
		}
		
		if (GUI.Button(new Rect(10,140,120,50),"Mix recordings")) {
			string[] files = new string[2];
			files[0] = Application.dataPath + "/AudioListener.wav";
			files[1] = Application.dataPath + "/Microphone.wav";
			//files[1] = Application.dataPath + "/AudioListener2.wav";
			
			EricOulashin.WAVFile.MergeAudioFiles(files, Application.dataPath + "/MixedAudio.wav", Application.dataPath + "/temp");
		}		
	}
}

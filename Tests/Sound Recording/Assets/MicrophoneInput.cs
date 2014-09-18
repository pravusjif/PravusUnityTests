﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
    public float sensitivity = 100;
    public float loudness = 0;

    void Start() {
        audio.clip = Microphone.Start(null, true, 10, 44100);
        audio.loop = true; // Set the AudioClip to loop
        audio.mute = true; // Mute the sound, we don't want the player to hear it
        //while (!(Microphone.GetPosition("AudioInputDevice") > 0)){} // Wait until the recording has started
    }

    void Update(){
        //loudness = GetAveragedVolume() * sensitivity;
		
		if(Input.GetMouseButtonDown(0)){
			audio.mute = false;
			audio.Play(); // Play the audio source!
		}
    }

float GetAveragedVolume()
    { 
        float[] data = new float[256];
        float a = 0;
        audio.GetOutputData(data,0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a/256;
    }
}
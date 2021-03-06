﻿using UnityEngine;
using System.Collections;
using System;

public class Sinus : MonoBehaviour
{
	// un-optimized version
	public double frequency = 440;
	public double gain = 0.05;
	private double increment;
	private double phase;
	private double sampling_frequency = 48000;
	
	private double[] tones = { 440.0f, 1046.5f, 3729.3f, 1046.5f };
	private int tone_index;
	private float last_time;
	
	void Start()
	{
		Debug.Log("" + tone_index + ": " + tones[tone_index]);     
	}
	
	void Update()
	{
		if (Time.realtimeSinceStartup - last_time > 1)
		{
			last_time = Time.realtimeSinceStartup;
			tone_index++;
			if (tone_index >= tones.Length)
				tone_index = 0;
			Debug.Log("" + tone_index + ": " + tones[tone_index]);
		}
	}
	
	void OnAudioFilterRead(float[] data, int channels)
	{
		// update increment in case frequency has changed
		increment = tones[tone_index] * 2 * Math.PI / sampling_frequency;
		
		for (var i = 0; i < data.Length; i += channels)
		{
			phase += increment;
			// this is where we copy audio data to make them “available” to Unity
			data[i] = (float) (gain * Math.Sin(phase));
			// if we have stereo, we copy the mono data to each channel
			if (channels == 2)
				data[i + 1] = data[i];
			if (phase > 2 * Math.PI)
				phase = 0;
		}
	}
}
using UnityEngine;
using System.Collections;

public class SampleProcessing : MonoBehaviour {
	public enum AudioSampleProcessingType{
		amplitude,
		decibels
	}

	public AudioSampleProcessingType type = AudioSampleProcessingType.amplitude;
	public float amplitude;
	public float db;
	float[] smooth = new float[2];
	
	void Start () {
		// initalising the filter
		for (int i = 0; i < 2; i++) {
			smooth [i] = 0.0f;	
		}
	}
	
	void Update () {
		//intensity of light, controlled by the amplitude of the sound

		if(type == AudioSampleProcessingType.amplitude)
			light.intensity = amplitude;
		else if(type == AudioSampleProcessingType.decibels)
			light.intensity = Mathf.Abs( db ) * 0.02f;
	}
	
	void OnAudioFilterRead (float[] data, int channels)
	{		
		for (var i = 0; i < data.Length; i = i + channels) {
			// the absolute value of every sample
			float absInput = Mathf.Abs(data[i]);
			db = 20 * Mathf.Log(absInput);

			// smoothening filter doing its thing
			smooth[0] = ((0.01f * absInput) + (0.99f * smooth[1]));
			// exaggerating the amplitude
			amplitude = smooth[0]*7;
			// it is a recursive filter, so it is doing its recursive thing
			smooth[1] = smooth[0];
		}
	}
}

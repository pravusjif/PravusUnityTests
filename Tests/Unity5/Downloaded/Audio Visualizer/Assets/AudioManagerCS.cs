using System;
using UnityEngine;
using System.Collections;

public class AudioManagerCS : MonoBehaviour {
    public FFTWindow fourierWindowType = FFTWindow.BlackmanHarris;
    static public float[] spectrum = new float[1024];

    AudioSource audioSource;
    float lastValue = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        // populate the floats array
        spectrum = audioSource.GetSpectrumData(2048, 0, fourierWindowType);
        
        /*float minValue = 0.4f;

        if (spectrum[1] > lastValue && spectrum[1] > minValue && lastValue < minValue)
            Debug.Log(spectrum[1]);

        lastValue = spectrum[1];*/
    }
}

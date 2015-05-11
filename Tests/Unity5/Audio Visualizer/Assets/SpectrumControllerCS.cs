using UnityEngine;
using System.Collections;

public class SpectrumControllerCS : MonoBehaviour {
    public int spectrumIndex;
    public BoxScalerCS boxScaler;
    public float scale = 32;

    void FixedUpdate()
    {
        float newScale = 1 + AudioManagerCS.spectrum[spectrumIndex] * scale;

        //if (spectrumIndex >= 2 && spectrumIndex < 3)
        //if (spectrumIndex == 1)
            boxScaler.desiredScale = newScale;
    }
}

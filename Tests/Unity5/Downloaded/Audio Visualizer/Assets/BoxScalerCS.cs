using UnityEngine;
using System.Collections;

public class BoxScalerCS : MonoBehaviour {
    public float desiredScale = 1.0f;
    Vector3 auxiliarVector;

    void FixedUpdate()
    {
        auxiliarVector = transform.localScale;

        auxiliarVector.z = Mathf.Lerp(transform.localScale.z, desiredScale, Time.deltaTime*8);

        transform.localScale = auxiliarVector;
    }
}

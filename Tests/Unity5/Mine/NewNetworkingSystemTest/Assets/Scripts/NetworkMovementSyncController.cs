using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkMovementSyncController : NetworkBehaviour
{
    public float lerpRate = 15f;

    [SyncVar]
    Vector3 syncPlayerPosition;

    [SyncVar]
    Quaternion syncPlayerRotation;

    Quaternion lastRotation;
    Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (isLocalPlayer && PositionOrRotationChanged())
        {
            CmdProvideValuesToServer(transform.position, transform.rotation);
        }
        else if(transform.position != syncPlayerPosition || transform.rotation != syncPlayerRotation)
        {
            LerpPosition();
            LerpRotation();
        }
    }

    [Command]
    void CmdProvideValuesToServer(Vector3 playerPosition, Quaternion playerRotation)
    {
        syncPlayerPosition = playerPosition;
        syncPlayerRotation = playerRotation;
    }

    void LerpPosition()
    {
        transform.position = Vector3.Lerp(transform.position, syncPlayerPosition, Time.deltaTime * lerpRate);
    }

    void LerpRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, syncPlayerRotation, Time.deltaTime * lerpRate);
    }

    bool PositionOrRotationChanged()
    {
        bool changed = false;

        if (transform.position != lastPosition)
        {
            changed = true;

            lastPosition = transform.position;
        }

        if (transform.rotation != lastRotation)
        {
            changed = true;

            lastRotation = transform.rotation;
        }

        return changed;
    }
}

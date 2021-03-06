﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkLocalComponentsEnabler : NetworkBehaviour
{
    public Behaviour[] behavioursToEnable;

    public override void OnStartLocalPlayer()
    {
	    if (isLocalPlayer)
	    {
	        for (int i = 0; i < behavioursToEnable.Length; i++)
	        {
	            behavioursToEnable[i].enabled = true;
	        }
	    }
	}
}

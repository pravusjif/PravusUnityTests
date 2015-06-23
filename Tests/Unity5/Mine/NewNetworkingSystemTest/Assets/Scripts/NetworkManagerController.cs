using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkManagerController : NetworkBehaviour
{
    NetworkManager netManager;

    void Awake()
    {
        netManager = GetComponent<NetworkManager>();
    }

    public void StartNewHost()
    {
        netManager.StartHost();
    }

    public void ConnectToDefaultHost()
    {
        netManager.StartClient();
    }
}

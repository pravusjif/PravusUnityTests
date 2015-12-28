using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

public class PlayerNetworkIdentifier : NetworkBehaviour
{
    [SyncVar] public string playerUniqueIdentity;

    private NetworkInstanceId playerNetworkID;
    private NetworkIdentity networkIdentity;

    public override void OnStartLocalPlayer()
    {
        networkIdentity = GetComponent<NetworkIdentity>();

        GetNetworkIdentity();
        SetNetworkIdentity();
    }

    void Update()
    {
        if (transform.name == "" || transform.name == "Player(Clone)")
        {
            SetNetworkIdentity();
        }
    }

    [Client]
    void GetNetworkIdentity()
    {
        playerNetworkID = networkIdentity.netId;

        CmdUpdatePlayerIDOnServer(MakeUniqueIdentity());
    }

    void SetNetworkIdentity()
    {
        if (!isLocalPlayer)
            transform.name = playerUniqueIdentity;
        else
            transform.name = MakeUniqueIdentity();
    }

    [Command]
    void CmdUpdatePlayerIDOnServer(string newIdentity)
    {
        playerUniqueIdentity = newIdentity;
    }

    string MakeUniqueIdentity()
    {
        return "Player " + playerNetworkID.ToString();
    }
}

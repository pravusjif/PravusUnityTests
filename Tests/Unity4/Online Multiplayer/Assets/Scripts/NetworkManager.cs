using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public string gameID = "Pravs_Multiplayer_Test";
	public GameObject playerPrefab = null;
	public Vector3 spawnPosition = Vector3.zero;
	float buttonXPos = Screen.width * 0.05f;
	float buttonYPos = Screen.height * 0.05f;
	float buttonWidth = Screen.width * 0.1f;
	float buttonHeight = Screen.width * 0.03f;
	HostData[] hosts = null;
	bool refreshing = false;

	void Update(){
		if(refreshing){
			hosts = MasterServer.PollHostList();

			if(hosts.Length > 0){
				refreshing = false;
				Debug.Log("Hosts found: " + hosts.Length);
			}
		}
	}

	void StartServer(){
		Network.InitializeServer(32, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost(gameID, "Multiplayer Test");
	}

	void RefreshHostsList(){
		refreshing = true;

		MasterServer.RequestHostList(gameID);
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized!");
		SpawnPlayer();
	}

	void OnConnectedToServer(){
		SpawnPlayer();
	}

	void OnMasterServerEvent(MasterServerEvent receivedEvent){
		if(receivedEvent == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Resgistration Succeded!");
		}
	}

	void SpawnPlayer(){
		Network.Instantiate(playerPrefab, spawnPosition, Quaternion.identity, 0);
	}

	void OnGUI(){
		if(!Network.isClient && !Network.isServer){
			if( GUI.Button(new Rect(buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Start Server") ){
				Debug.Log("Starting Server...");
				StartServer();
			}

			if( GUI.Button(new Rect(buttonXPos, buttonYPos * 1.2f + buttonHeight, buttonWidth, buttonHeight), "Refresh Hosts") ){
				Debug.Log("Refreshing...");
				RefreshHostsList();
			}

			if(hosts != null && hosts.Length > 0){
				for(int i = 0; i < hosts.Length; i++){
					if(GUI.Button(new Rect(buttonXPos * 1.5f + buttonWidth, buttonYPos + (i * buttonHeight), buttonWidth, buttonHeight), hosts[i].gameName)){
						Network.Connect(hosts[i]);
					}
				}
			}
		}
	}
}

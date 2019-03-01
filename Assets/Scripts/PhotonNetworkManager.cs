using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : MonoBehaviour {

    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lobbyCamera;
    [SerializeField] private Transform spawnPoint;
    // Use this for initialization
    void Start() {
        PhotonNetwork.ConnectUsingSettings("v1");
    }



    public virtual void OnJoinedLobby(){
        Debug.Log("We have now joined the lobby");

       // RoomOptions roomOptions = new RoomOptions();
        //join room if exists or create one
        PhotonNetwork.JoinOrCreateRoom("New", null, null);
    }

    public virtual void OnJoinedRoom()
    {
        // Spawn in the player
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        //deactivat elobby camera
        lobbyCamera.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}

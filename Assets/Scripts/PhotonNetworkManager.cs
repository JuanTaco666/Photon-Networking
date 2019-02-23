using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.MonoBehaviour {

    [SerializeField] private Text connectText;
    // Use this for initialization
    void Start() {
        PhotonNetwork.ConnectUsingSettings("v1");
    }


    public virtual void OnConnectedToMaster(){
        Debug.Log("We are now connected to master");
    }

	// Update is called once per frame
	void Update () {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}

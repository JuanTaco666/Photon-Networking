using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {
    [SerializeField] private GameObject playerCamera;
    //any scripts for non local player which i want to disable
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    private PhotonView photonView;

    public int playerHealth = 100;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
    }
    private void Initialize()
    {
        if (photonView.isMine)
        {

        } else
        //handle functionality for non local character
        {
            //disable it's camera
            playerCamera.SetActive(false);
            //disable it's control scripts
            foreach(MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }



    }

    private void Update()
    {
        if (!photonView.isMine)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth -= 5;
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        //sending data
        if (stream.isWriting)
        {
            stream.SendNext(playerHealth);
        }
        //recieveing data
        else if (stream.isReading)
        {
            playerHealth = (int)stream.ReceiveNext();
        }
    }
        
}

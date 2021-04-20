using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine.UI;
using System;

namespace DroneWork
{
    public class IP_Menu : MonoBehaviour
    {
        public GameObject menuPanel;
        public InputField inputField;


        private void Start()
        {
            NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        }

        private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
        {
            //Logic
            bool approve = false;
            //if connection is correct then we join
            string password = System.Text.Encoding.ASCII.GetString(connectionData);
            if (password == "mygame")
            {
                //we can join
                approve = true;
            }
            Debug.Log($"Approval: {approve}");
            callback(true, null, approve, new Vector3(0,10,0), Quaternion.identity);
        }

        public void Host()
        {
            NetworkManager.Singleton.StartHost();
            menuPanel.SetActive(false);
        }
        public void Join()
        {
            //Clicked join
            if (inputField.text.Length <= 0)
            {
                NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = "127.0.0.1";
            }
            else
            {
                NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = inputField.text;
            }
            NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("mygame");
            NetworkManager.Singleton.StartClient();
            menuPanel.SetActive(false);
        }

    }
}
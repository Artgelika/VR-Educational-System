using Photon.Pun;
using UnityEngine;

public class ServerConnection : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Function that enables user to connect to the server which allow them 
    /// appear to the lobby and choose specific room (laboratory)
    /// </summary>
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
    }
}

using Photon.Pun;
using UnityEngine;

public class NetworkManagerRoom : NetworkManagerBase
{
    [SerializeField]
    private string _roomName;
    /// <summary>
    /// 
    /// </summary>
    public override void OnConnectedToMaster()
    {
        // if (NetworkingClient.Server != ServerConnection.MasterServer)
        //NetworkingClient.Server != ServerConnection.MasterServer
        base.OnConnectedToMaster();
        PhotonNetwork.JoinRoom(_roomName);
        Debug.Log("Joined a Room");
    }
}

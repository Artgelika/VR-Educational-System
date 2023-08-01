using UnityEngine;
using Photon.Pun;

public class NetworkManagerLobby : NetworkManagerBase
{
    public GameObject roomUI;

    /// <summary>
    /// After appearing to the game user appears in lobby
    /// Lobby is a default room and the first room in visualization
    /// </summary>
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    /// <summary>
    /// Enables get into a lobby
    /// button appers 
    /// </summary>
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        roomUI.SetActive(true);
    }
}

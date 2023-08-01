using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerBase : MonoBehaviourPunCallbacks, INetworkManager
{
    public List<DefaultRoom> defaultRooms;

    public void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    /// <summary>
    /// 
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        //PhotonNetwork.JoinLobby();
    }

    /// <summary>
    /// Specific room - laboratory is created. 
    /// 
    /// Creating a room is needed before user join room by clicking 
    /// a button in lobby
    /// 
    /// Room has maximal number of players in it;
    /// is visible or not
    /// is able to join (is open) or not
    /// </summary>
    public void InitializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        // Load scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);
        RoomOptions roomOptions = CreateRoom(roomSettings);

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    private RoomOptions CreateRoom(DefaultRoom roomSettings)
        => new()
        {
            MaxPlayers = (byte)roomSettings.maxPlayer,
            IsVisible = true,
            IsOpen = true
        };


    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    /// <summary>
    /// Enables get into a lobby
    /// button appers 
    /// </summary>
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We joined a lobby");
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }
}

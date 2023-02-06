using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject roomUI;
    
    /// <summary>
    /// Function that enables user to connect to the server which allow them 
    /// appear to the lobby and choose specific room (laboratory)
    /// </summary>
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server...");
    }

    /// <summary>
    /// After appearing to the game user appears in lobby
    /// Lobby is a default room and the first room in visualization
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
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
        Debug.Log("We joined a lobby");
        roomUI.SetActive(true);
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
    public void InitializeRoom()
    {
        RoomOptions roomOptions = new()
        {
            MaxPlayers = 10,
            IsVisible = true,
            IsOpen = true
        };
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    


    




}

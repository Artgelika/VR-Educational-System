using Photon.Pun;
using UnityEngine;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Class is responsible for creating each user separately.
    /// User is creating during joining to the room,
    /// and deleting when user left the room.
    /// </summary>
    private GameObject spawnedPlayerPrefab;
    public override void OnJoinedLobby()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
using Photon.Realtime;

public interface INetworkManager
{
    void OnConnectedToMaster();
    void InitializeRoom(int defaultRoomIndex);
    void OnJoinedRoom();
    void OnPlayerEnteredRoom(Player newPlayer);
}

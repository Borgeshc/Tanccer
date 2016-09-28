using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour
{
    public string version = "v1.1.5";
    public string roomName;
    public GameObject playerOneTank;
    public GameObject playerTwoTank;
    public GameObject p1Spawn;
    public GameObject p2Spawn;

    GameObject canvas;
    GameObject player;
    GameObject[] players;
    // Use this for initialization
    void Start ()
    {
        PhotonNetwork.QuickResends = 3;
        PhotonNetwork.ConnectUsingSettings(version);    //Connects to the photon network using the app ID you entered.
        canvas = GameObject.Find("Canvas");
    }

    private void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    private void OnPhotonRandomJoinFailed()
    {
        Debug.LogError("JoinLobbyFailed!");
    }
    private void OnJoinedRoom()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        if (PhotonNetwork.playerList.Length == 1)
        {
            print("Called for player one");
            player = PhotonNetwork.Instantiate(playerOneTank.name, p1Spawn.GetComponent<RectTransform>().position, p1Spawn.GetComponent<RectTransform>().rotation, 0);
            player.GetComponent<PhotonView>().RPC("ChildPlayer", PhotonTargets.AllBuffered);
            //player.transform.SetParent(canvas.transform);
            player.name = "TankLeft";
        }
        else if (PhotonNetwork.playerList.Length == 2)
        {
            print("Called for player 2");
            player = PhotonNetwork.Instantiate(playerTwoTank.name, p2Spawn.GetComponent<RectTransform>().position, p2Spawn.GetComponent<RectTransform>().rotation, 0);
            player.GetComponent<PhotonView>().RPC("ChildPlayer", PhotonTargets.AllBuffered);
            //player.transform.SetParent(canvas.transform);
            player.name = "TankRight";
        }

        //for(int i = 0; i < PhotonNetwork.playerList.Length; i++)
        //{
        //    PhotonNetwork.playerList[i].TagObject = "Player";
        //}
        //players = GameObject.FindGameObjectsWithTag("Player");
        //for (int i = 0; i < players.Length; i++)
        //{
        //    players[i].transform.SetParent(canvas.transform);
        //}
    }

    
}

using UnityEngine;
using UnityEngine.UI;

public class RandomMatchmaker : Photon.PunBehaviour
{
    private PhotonView myPhotonView;

    // Use this for initialization
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinRandom");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        // when AutoJoinLobby is off, this method gets called when PUN finished the connection (instead of OnJoinedLobby())
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    { // if playerprefs = ..... else
        GameObject monster = PhotonNetwork.Instantiate("Shiba Inu", Vector3.zero, Quaternion.identity, 0);
        // monster.GetComponent<myThirdPersonController>().isControllable = true;
       // monster.GetComponent<BallDogController>().enabled = true;
       
        myPhotonView = monster.GetComponent<PhotonView>();
       
        PhotonNetwork.playerName = "Player" + PhotonNetwork.player.ID;
        monster.transform.Find("NameTag/Name").GetComponent<Text>().text = PhotonNetwork.playerName;

    }

    public void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

        if (PhotonNetwork.inRoom)
        {
            bool shoutMarco = GameLogic.playerWhoIsIt == PhotonNetwork.player.ID;

            if (shoutMarco && GUILayout.Button("Player 1"))
            {
                myPhotonView.RPC("Marco", PhotonTargets.All);
            }
            if (!shoutMarco && GUILayout.Button("Player 2"))
            {
                myPhotonView.RPC("Polo", PhotonTargets.All);
            }
        }
    }
}

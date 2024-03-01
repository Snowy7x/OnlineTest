using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onJoinLobby;
    [SerializeField] private UnityEvent onJoinedMaster;
    [SerializeField] private UnityEvent onTryToJoin;
    [SerializeField] private UnityEvent onJoinFailed;
    
    public void Start()
    {
        onStart?.Invoke();
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void JoinRandom()
    {
        onTryToJoin?.Invoke();
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    
    #region PunCALLBACKS

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        onJoinedMaster?.Invoke();
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }


    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        onJoinLobby?.Invoke();
        base.OnJoinedLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        onJoinFailed?.Invoke();
        base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        onJoinFailed?.Invoke();
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnCreatedRoom()
    {
        SceneManager.LoadScene(1);
        base.OnCreatedRoom();
    }

    #endregion
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Multyserver : MonoBehaviour {

    public Transform cubePrefab;
    public List<Transform> playerList = new List<Transform>();

    void Start() {
        InvokeRepeating("CheckList", 0.25f, 0.25f);
    }

    void CheckList() {
        for (int i = 0; i < playerList.Count; i++) {
            if (playerList[i] == null) {
                playerList.RemoveAt(i);
            }
        }
    }

    void OnServerInitialized()
    {
       SpawnPlayer();
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        playerList.Add((Transform)Network.Instantiate(cubePrefab, transform.position, transform.rotation, 0));
    }

    void RemovePlayer()
    {
        Destroy(cubePrefab);
    }
}

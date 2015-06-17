using UnityEngine;
using System.Collections;

public class CheckPlayers : MonoBehaviour {

    public GameObject singleplayerScreen;
    public GameObject multiplayerScreen;
    public GameObject endScreen;

    private Multyserver multyserver;

    private int players;
    private bool multiplayer = false;

    void Awake() {
        multyserver = GameObject.Find("Server").GetComponent<Multyserver>();
    }
    void Start() {
        endScreen.SetActive(false);
        InvokeRepeating("CheckSnakes", 0.25f, 0.25f);
    }
    void CheckSnakes() {
        if (multyserver.playerList.Count > players) {
            players++;
            if (players > 1) {
                multiplayer = true;
            }
        }
        else if (multyserver.playerList.Count < players) {
            players--;
            if (players == 1 && multiplayer == true) {
                endScreen.SetActive(true);
                multiplayerScreen.SetActive(false);
                singleplayerScreen.SetActive(true);
            }
            else if (players == 0) {
                endScreen.SetActive(true);
                multiplayerScreen.SetActive(true);
                singleplayerScreen.SetActive(false);
            }
        }
    }
    public string snakeColor() {
        string color = multyserver.playerList[0].name;
        if (color == "HeadBlue") {
            color = "blue";
        }
        else if (color == "HeadBrown") {
            color = "brown";
        }
        else if (color == "HeadGreen") {
            color = "green";
        }
        else if (color == "HeadGrey") {
            color = "grey";
        }
        else if (color == "HeadWhite") {
            color = "white";
        }
        else if (color == "HeadYellow") {
            color = "yellow";
        }
        return (color);
    }
}

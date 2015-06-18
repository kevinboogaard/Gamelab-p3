using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

    private Text text;
    private CheckPlayers checkplayer;

    void Awake() {
        text = GetComponent<Text>();
        checkplayer = GetComponentInParent<CheckPlayers>();
    }
    void OnEnable() {
        UpdateColor();
    }
    void UpdateColor() {
        string color = checkplayer.snakeColor();
        if (color == "blue") {
            text.text = "BLUE";
            text.color = new Color(0.04F, 0.24f, 0.47f); ;
        }
        else if (color == "brown") {
            text.text = "BROWN";
            text.color = new Color(0.52f, 0.33f, 0.21f);
        }
        else if(color == "green"){
            text.text = "GREEN";
            text.color = new Color(0.4f, 0.51f, 0.6f);
        }
        else if (color == "grey") {
            text.text = "GREY";
            text.color = new Color(0.59f, 0.58f, 0.61f);
        }
        else if (color == "white") {
            text.text = "WHITE";
            text.color = new Color(1, 1, 1);
        }
        else if (color == "yellow") {
            text.text = "YELLOW";
            text.color = new Color(1, 0.89f, 0.38f);
        }
    }
}

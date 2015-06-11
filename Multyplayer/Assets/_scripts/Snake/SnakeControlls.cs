using UnityEngine;
using System.Collections;

public class SnakeControlls : MonoBehaviour {

    delegate void GoDir(Vector2 dir);
    GoDir MoveDir;

    void Start() {
        MoveDir = KeyPressed;
        MoveDir += GetComponent<Snake>().ChangeDir;
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            KeyPressed(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            KeyPressed(-Vector2.up);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            KeyPressed(-Vector2.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            KeyPressed(Vector2.up);
        }
    }
    void KeyPressed(Vector2 dir) {

    }
}

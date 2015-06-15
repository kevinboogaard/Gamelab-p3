using UnityEngine;
using System.Collections;

public class SnakeControlls : MonoBehaviour {

    delegate void GoDir(Vector2 dir);
    GoDir MoveDir;

    void Start() {
        MoveDir = GetComponent<Snake>().ChangeDir;
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            MoveDir(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            MoveDir(-Vector2.up);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            MoveDir(-Vector2.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            MoveDir(Vector2.up);
        }
    }
}

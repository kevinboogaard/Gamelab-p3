using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public Vector2 dir = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private bool ate = false;
    private Vector2 movedDir;

    public GameObject tailPrefab;

    void Start() {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow) && movedDir != -Vector2.right) {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && movedDir != Vector2.up) {
            dir = -Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && movedDir != Vector2.right) {
            dir = -Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && movedDir != -Vector2.up) {
            dir = Vector2.up;
        }
    }

    void Move() {
        movedDir = dir;
        Vector2 v = transform.position;
        int rotationTail = Mathf.RoundToInt(transform.rotation.eulerAngles.z);
        int rotation;

        if (rotationTail == 90 || rotationTail == 270) {
            rotationTail = -rotationTail;
        }

        transform.Translate(dir, Space.World);
        if (dir == Vector2.right) {
            rotation = 270;
        }
        else if (dir == Vector2.up) {
            rotation = 180;
        }
        else if (dir == -Vector2.up) {
            rotation = 0;
        }
        else {
            rotation = 90;
        }
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.back);
        if (ate) {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            g.transform.rotation = Quaternion.AngleAxis(rotationTail, Vector3.back);
            tail.Insert(0, g.transform);

            ate = false;
        }
        else if (tail.Count > 0) {
            tail.Last().position = v;
            tail.Last().transform.rotation = Quaternion.AngleAxis(rotationTail, Vector3.back);

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        if (tail.Count > 0) {
            tail.Last().GetComponent<ChangeTailArt>().ChangeArt(true);
        }
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "pickup") {
            ate = true;

            Destroy(coll.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("death " + gameObject.name);
        for (int i = 0; i < tail.Count; i++) {
            Destroy(tail[i]);
        }
        Destroy(gameObject);
    }
}

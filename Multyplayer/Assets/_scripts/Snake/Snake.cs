using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public Vector2 dir = Vector2.right;
    private List<GameObject> tail = new List<GameObject>();
    private bool ate = true;
    private Vector2 movedDir;
    private float speed = 0.3f;
    private bool speedChange = false;
    private bool enabled = true;

    public GameObject tailPrefab;

    void Start() {
        InvokeRepeating("Move", speed, speed);
    }

    void Awake()
    {
        if (!GetComponent<NetworkView>().isMine) {
            enabled = false;
        }
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (stream.isWriting)
        {
            Vector3 myPosition = transform.position;
            stream.Serialize(ref myPosition);
        }
        else
        {
            Vector3 receivedPosition = Vector3.zero;
            stream.Serialize(ref receivedPosition);
            transform.position = receivedPosition;
        }
    }

    public void ChangeDir(Vector2 direction) {
        Debug.Log(dir + " ChangeDir");
        if (direction == Vector2.right && movedDir != -Vector2.right) {
            dir = Vector2.right;
        }
        else if (direction == -Vector2.up && movedDir != Vector2.up) {
            dir = -Vector2.up;
        }
        else if (direction == -Vector2.right && movedDir != Vector2.right) {
            dir = -Vector2.right;
        }
        else if (direction == Vector2.up && movedDir != -Vector2.up) {
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
            tail.Insert(0, g);

            ate = false;
        }
        else if (tail.Count > 0) {
            tail.Last().transform.position = v;
            tail.Last().transform.rotation = Quaternion.AngleAxis(rotationTail, Vector3.back);

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        if (tail.Count > 0) {
            tail.Last().GetComponent<ChangeTailArt>().ChangeArt(true, speed);
        }
        if (speedChange == true) {
            CancelInvoke("Move");
            InvokeRepeating("Move", speed, speed);
        }
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "growPickup") {
            ate = true;
            Debug.Log("GrowPickup " + name);
        }
        else if (coll.tag == "speedUpPickup") {
            if (speed > 0.15f) {
                speed -= 0.05f;
                speedChange = true;
                Debug.Log("speedUpPickup " + name + " " + speed);
            }
        }
        else if(coll.tag == "speedDownPickup") {
            speed += 0.1f;
            speedChange = true;
            Debug.Log("speedDownPickup " + name + " " + speed);
        }
        Destroy(coll.gameObject);
    }
    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("death " + gameObject.name);
        CancelInvoke("Move");
        for (int i = 0; i < tail.Count; i++) {
            Destroy(tail[i]);
        }
        Destroy(gameObject);
    }
}

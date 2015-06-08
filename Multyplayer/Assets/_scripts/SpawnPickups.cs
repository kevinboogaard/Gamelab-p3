using UnityEngine;
using System.Collections;

public class SpawnPickups : MonoBehaviour {

    public GameObject growPrefab;
    public GameObject speedUpPrefab;
    public GameObject speedDownPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;


    void Start() {
        InvokeRepeating("Spawn", 3, 10);
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

    void Spawn() {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        int Q = Random.Range(0, 3);
        if (Q == 0) {
            Instantiate(growPrefab, new Vector2(x, y), Quaternion.identity);
        }
        else if (Q == 1) {
            Instantiate(speedUpPrefab, new Vector2(x, y), Quaternion.identity);
        }
        else {
            Instantiate(speedDownPrefab, new Vector2(x, y), Quaternion.identity);
        }
    }
}

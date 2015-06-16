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

    private bool server = true;

    private int antiLoop = 0;

    /*void Update()
    {
        if (Network.isServer == true && server == true)
        {
            Begin();
            server = false;
        }
    }*/

    void Start() {
        InvokeRepeating("Spawn", 0, 1);
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
    [RPC]
    void Spawn() {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y),Vector2.up, 0.1f);
        if (hit.collider != null) {
            Debug.Log("raycast hit object, choosing different location " + antiLoop);
            if (antiLoop < 30) {
                Spawn();
                antiLoop++;
            }
            else {
                antiLoop = 0;
            }
        }
        else {
            antiLoop = 0;
            int Q = Random.Range(0, 4);
            if (Q == 0) {
                Instantiate(growPrefab, new Vector2(x, y), Quaternion.identity);
            }
            else if (Q == 1 || Q == 2) {
                Instantiate(speedUpPrefab, new Vector2(x, y), Quaternion.identity);
            }
            else {
                Instantiate(speedDownPrefab, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}

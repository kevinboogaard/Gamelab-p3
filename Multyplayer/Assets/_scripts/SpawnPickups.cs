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

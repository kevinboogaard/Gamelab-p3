using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {

    public GameObject obstacle1;
    public GameObject obstacle2;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    
    private int antiLoop = 0;
    void Start() {
        Spawn();
    }

	void Spawn () {
        int obstacles = Random.Range(0, 6);
        //Debug.Log(obstacles);
        for (int i = 0; i < obstacles; i++) {
            int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
            int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(x, y),Vector2.up, 0.1f);
            if (hit.collider != null) {
                Debug.Log("raycast hit object, choosing different location " + antiLoop);
                if (antiLoop < 100) {
                    Spawn();
                    antiLoop++;
                }
                else {
                    antiLoop = 0;
                }
            }
            else {
                int Q = Random.Range(0, 2);
                if (Q == 0) {
                    Instantiate(obstacle1, new Vector2(x, y), Quaternion.identity);
                }
                else {
                    Instantiate(obstacle2, new Vector2(x, y), Quaternion.identity);
                }
            }
        }
	}
}

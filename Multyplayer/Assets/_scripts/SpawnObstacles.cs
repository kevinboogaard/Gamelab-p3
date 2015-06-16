using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {

    public GameObject obstacle1;
    public GameObject obstacle2;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start() {
        Spawn();
    }

	void Spawn () {
        int obstacles = Random.Range(0, 6);
        //Debug.Log(obstacles);
        for (int i = 0; i < obstacles; i++) {
            int x = (int)Random.Range(borderLeft.position.x+1, borderRight.position.x-1);
            int y = (int)Random.Range(borderBottom.position.y+1, borderTop.position.y-1);

            RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(x, y-1),Vector2.up, 2);
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(x, y), Vector2.up, 2);
            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(x, y + 1), Vector2.up, 2);
            if (hit1.collider == false || hit2.collider == false || hit3 == false) {
                int Q = Random.Range(0, 2);
                if (Q == 0) {
                    Instantiate(obstacle1, new Vector2(x, y), Quaternion.identity);
                }
                else {
                    Instantiate(obstacle2, new Vector2(x, y), Quaternion.identity);
                }
            }
            else {
                if(obstacles > 10){
                    obstacles = 0;
                }
                else {
                    obstacles++;
                }
            }
        }
	}
}

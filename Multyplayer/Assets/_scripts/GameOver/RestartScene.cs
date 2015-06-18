using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour {

	void Update () {
        if (Input.anyKey) {
            Application.LoadLevel(Application.loadedLevelName);
        }
	}
}

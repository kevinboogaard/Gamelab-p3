using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject startButtonB;
    public GameObject optionsButtonB;
    public GameObject quitButtonB;
    public GameObject menu;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (startButtonB.active == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            startButtonB.SetActive(false);
            optionsButtonB.SetActive(true);
        }
        else if (optionsButtonB.active == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            optionsButtonB.SetActive(false);
            quitButtonB.SetActive(true);
        }
        else if (quitButtonB.active == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            quitButtonB.SetActive(false);
            startButtonB.SetActive(true);           
        }

        if(startButtonB.active == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            startButtonB.SetActive(false);
            quitButtonB.SetActive(true);   
        }
        else if (optionsButtonB.active == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            optionsButtonB.SetActive(false);
            startButtonB.SetActive(true);
        }
        else if (quitButtonB.active == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            quitButtonB.SetActive(false);
            optionsButtonB.SetActive(true);
        }

        if (startButtonB.active == true && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            
        }
	}
}

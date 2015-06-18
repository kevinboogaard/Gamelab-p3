using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject startButtonB;
    public GameObject optionsButtonB;
    public GameObject quitButtonB;
    public GameObject connect;
    public GameObject connectB;
    public GameObject host;
    public GameObject hostB;
    public GameObject menu;

    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
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

        if (startButtonB.active == true && Input.GetKeyDown(KeyCode.RightArrow)&& hostB.active == true)
        {
            hostB.SetActive(false);
            connectB.SetActive(true);
        }
        else if (startButtonB.active == true && Input.GetKeyDown(KeyCode.RightArrow) && connectB.active == true)
        {
            hostB.SetActive(true);
            connectB.SetActive(false);
        }
        if (startButtonB.active == true && Input.GetKeyDown(KeyCode.KeypadEnter) && connectB.active == true)
        {
            Network.Connect(connectionIP, connectionPort);
            menu.SetActive(false);
        }
        else if (startButtonB.active == true && Input.GetKeyDown(KeyCode.KeypadEnter) && hostB.active == true)
        {
            Network.InitializeServer(32, connectionPort, false);
            menu.SetActive(false);
        }
	}
}

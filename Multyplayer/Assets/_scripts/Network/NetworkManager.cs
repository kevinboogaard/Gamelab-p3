using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{

    private HostData[] _hostList;

    private const string _typeName = "UniqueGameName";
    private const string _gameName = "RoomName";

    // Use this for initialization
    void StartServer()
    {
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(_typeName, _gameName);
    }

    // Update is called once per frame
    void OnServerInitialized()
    {
        Debug.Log("Server Initalizied");
    }

    private void RefreshHostList()
    {
        MasterServer.RequestHostList(_typeName);
    }
    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.HostListReceived)
        {
            _hostList = MasterServer.PollHostList();
        }
    }

    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                StartServer();
            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
                RefreshHostList();

            if (_hostList != null)
            {
                for (int i = 0; i < _hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), _hostList[i].gameName))
                    {
                        JoinServer(_hostList[i]);
                    }
                }
            }
        }
    }
}

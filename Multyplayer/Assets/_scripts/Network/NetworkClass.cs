using UnityEngine;
using System.Collections;

public class NetworkClass : MonoBehaviour {

    void Awake()
    {
        if (!GetComponent<NetworkView>().isMine)
        {
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
}

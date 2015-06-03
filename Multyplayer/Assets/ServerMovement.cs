﻿using UnityEngine;
using System.Collections;

public class ServerMovement : MonoBehaviour
{

    void Awake()
    {
        if (!GetComponent<NetworkView>().isMine)
            enabled = false;
    }

    void Update()
    {

        if (GetComponent<NetworkView>().isMine)
        {
            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            float speed = 5;
            transform.Translate(speed * moveDir * Time.deltaTime);

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

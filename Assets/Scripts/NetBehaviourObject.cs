using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetBehaviourObject : NetworkBehaviour
{
    [SerializeField]
    private UIEventTest _eventTest;

    [SerializeField]
    private float speed;

    [SyncVar]
    private Vector3 _pos;

    private Transform cachedTf;

    private void Awake()
    {
        _eventTest = FindObjectOfType<UIEventTest>();
        cachedTf = transform;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();

        Debug.Log("OnStartServer");
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("OnStartClient");
    }

    [ClientRpc]
    private void RpcMethod(uint netIdValue)
    {
        _eventTest.RpcMethod(netIdValue);
    }
    
    
    [ClientRpc]
    private void RpcMethodFromCommand(uint netIdValue)
    {
        _eventTest.RpcMethodFromCommand(netIdValue);
    }

    [Command]
    private void CmdMethod(uint netIdValue)
    {
        _eventTest.CmdMethod(netIdValue);

        // if (isServer)
        // {
        //     RpcMethodFromCommand();
        //     ServerMethodFromCommand();
        // }
    }

    [Server]
    private void ServerMethodFromCommand(uint netIdValue)
    {
        _eventTest.MethodServerFromCommand(netIdValue);
    }

    [Client]
    private void MethodClient(uint netIdValue)
    {
        _eventTest.MethodClient(netIdValue);
    }

    [Server]
    private void MethodServer(uint netIdValue)
    {
        _eventTest.MethodServer(netIdValue);
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            Move();
        }
        else
        {
            transform.position = _pos;
        }

        DoMethod();
    }

    private void DoMethod()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RpcMethod(netId.Value);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CmdMethod(netId.Value);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MethodClient(netId.Value);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MethodServer(netId.Value);
        }
    }


    private void Move()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1f;
        }

        float deltaTime = Time.deltaTime;
        float deltaX = x * speed * deltaTime;
        float deltaY = y * speed * deltaTime;

        cachedTf.Translate(deltaX, deltaY, 0);

        CmdPos(cachedTf.position);
    }

    [Command]
    private void CmdPos(Vector3 pos)
    {
        _pos = pos;
    }
}
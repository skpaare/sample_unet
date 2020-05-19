using System;
using UnityEngine;
using UnityEngine.Networking;

internal class GlobalOption : MonoBehaviour
{
    public RunType runType;

    private void Awake()
    {
        if (runType == RunType.Server)
        {
            NetworkManager.singleton.StartServer();
        }
    }
}

enum RunType
{
    Server,
    Client,
}
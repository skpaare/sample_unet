using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class NetObjNavMesh : NetworkBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform cachedTf;

    [SyncVar]
    private Vector3 _pos;

    [Command]
    private void CmdSetPos(Vector3 position)
    {
        _pos = position;
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetDestinationToMousePosition();
            }

            CmdSetPos(cachedTf.position);
        }
        else
        {
            cachedTf.position = _pos;
        }
    }

    void SetDestinationToMousePosition()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
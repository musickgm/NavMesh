﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DirectedAgent : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToLocation(Vector3 targetPoint)
    {
        agent.destination = targetPoint;
        agent.isStopped = false;
    }


}

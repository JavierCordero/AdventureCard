using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalZombieBehaviour : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        if (!gm)
            gm = FindObjectOfType<GameManager>();

        GetComponent<NavMeshAgent>().SetDestination(gm.GetClosestFence(transform.position).transform.GetChild(2).position);
    }
}

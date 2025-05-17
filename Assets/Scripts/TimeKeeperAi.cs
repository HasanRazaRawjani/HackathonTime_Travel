using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimeKeeperAi : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TimeTravel timeTravel = collision.gameObject.GetComponent<TimeTravel>();
            if (timeTravel != null)
            {
                timeTravel.die();
            }
        }
    }

}
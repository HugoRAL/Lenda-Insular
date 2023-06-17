using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Animator animator;
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 destPoint;
    bool walkpointset;
    [SerializeField] float range;
    [SerializeField] float followRange = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Running", false);
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= followRange)
            {
                agent.SetDestination(player.transform.position);
                animator.SetBool("Running", true);
            }
            else if (distanceToPlayer > followRange && agent.hasPath)
            {
                agent.ResetPath(); // Stop the enemy from moving
            }
        }
    }

    void Patrol()
    {
        if (!walkpointset)
            SearchForDest();

        if (walkpointset)
            agent.SetDestination(destPoint);

        if (Vector3.Distance(transform.position, destPoint) < 10)
        {
            walkpointset = false;
            animator.SetBool("Running", false);
        }
    }

    void SearchForDest()
    {
        animator.SetBool("Running", true);
        float Z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + Z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointset = true;
        }
    }
}

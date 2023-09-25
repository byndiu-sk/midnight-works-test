using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent agent = null;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget >= agent.stoppingDistance)
        {
            animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
        }
    }
}

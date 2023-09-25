using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float timeOfLastAttack = 0;
    private bool hasStopped;

    private NavMeshAgent agent = null;
    private Animator animator = null;
    private ZombieStats stats = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stats = GetComponent<ZombieStats>();
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
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);

            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }

            if (Time.time >= timeOfLastAttack + stats.atackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        animator.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }
}

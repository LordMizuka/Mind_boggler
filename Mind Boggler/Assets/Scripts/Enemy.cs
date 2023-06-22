using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Range(0, 50)][SerializeField] float attackRange = 5, sightRange = 20, timeBetweenAttacks = 3;

    private NavMeshAgent thisEnemy;
    public Transform playerPos;

    private bool isAttacking; // If the enemy is currently attacking

    private void Start()
    {
        thisEnemy = GetComponent <NavMeshAgent>();
        playerPos = FindObjectOfType<playerContoller>().transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(playerPos.position, this.transform.position);// The distance between the player and the enemy

        if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange)
        {
            isAttacking = false;
            StopAllCoroutines();
            thisEnemy.isStopped = false;

            ChasePlayer();
        }

        if (distanceFromPlayer <= attackRange && !isAttacking)
        {
            thisEnemy.isStopped = true; // Stop the enemy from moving
            StartCoroutine(AttackPlayer()); // Start attacking the player
        }
    }

    private void ChasePlayer()
    {

    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        yield return new WaitForSeconds(timeBetweenAttacks); // Wait for the time between attacks.

        Debug.Log("Hurt player");

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
    }

}

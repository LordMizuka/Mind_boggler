using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent enemyAgent;
    private bool isStunned = false;
    private Rigidbody enemyRigidbody;

    [SerializeField] private float stunDuration = 2f;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Update the destination to the player's position
            enemyAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player game object
            Destroy(collision.gameObject);

            SceneManager.LoadScene("Game");
        }
    }

    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;

            // Stop the enemy from moving by freezing its rigidbody
            enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;

            // Start a coroutine to end the stun after the specified duration
            StartCoroutine(EndStun());
        }
    }

    public IEnumerator EndStun()
    {
        yield return new WaitForSeconds(stunDuration);

        // Enable the enemy's movement by removing the rigidbody constraints
        enemyRigidbody.constraints = RigidbodyConstraints.None;

        isStunned = false;
    }

}
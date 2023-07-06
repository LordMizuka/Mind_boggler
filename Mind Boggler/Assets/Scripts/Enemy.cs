using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent enemyAgent;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
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
}
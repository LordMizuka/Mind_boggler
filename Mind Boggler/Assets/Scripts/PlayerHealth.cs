using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 200)] public int startHealth = 1, currentHealth;

    public static bool isDead;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Destroy the player game object
            Destroy(other.gameObject);
        }
    }

    private void start()
    {
        currentHealth = startHealth;// Set the current health to be the start health, when the game starts.
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("You Died");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
}

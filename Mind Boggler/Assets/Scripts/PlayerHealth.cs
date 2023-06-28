using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 200)] public int startHealth = 1, currentHealth;

    public static bool isDead;

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

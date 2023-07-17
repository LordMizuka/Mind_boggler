using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public float stunDuration = 2f;
    public GameObject spearPrefab; // Reference to the spear prefab

    private GameObject player;
    private GameObject currentSpear;
    private bool isHoldingSpear = false;
    private bool isStunned = false;
    private Enemy currentEnemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isHoldingSpear)
        {
            // Spawn the spear in front of the player
            currentSpear = Instantiate(spearPrefab, player.transform.position + player.transform.forward, player.transform.rotation);

            // Attach the spear to the player as a child
            currentSpear.transform.parent = player.transform;
            currentSpear.transform.localPosition = Vector3.zero;
            currentSpear.transform.localRotation = Quaternion.identity;

            isHoldingSpear = true;
        }

        if (isHoldingSpear)
        {
            // Align the spear with the player's movement direction
            Vector3 movementDirection = player.GetComponent<Rigidbody>().velocity.normalized;
            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                currentSpear.transform.rotation = Quaternion.Lerp(currentSpear.transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHoldingSpear && !isStunned && other.CompareTag("Enemy"))
        {
            // Get the Enemy component from the collided enemy
            currentEnemy = other.GetComponent<Enemy>();

            // Stun the enemy
            currentEnemy.Stun();

            // Start a coroutine to end the stun after the specified duration
            StartCoroutine(EndStun());
        }
    }

    private IEnumerator EndStun()
    {
        yield return new WaitForSeconds(stunDuration);

        // Enable the enemy's movement
        currentEnemy.EndStun();

        // Remove the spear from the player
        Destroy(currentSpear);
        isHoldingSpear = false;
        isStunned = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        canPickUp = true;


    }
    public bool canPickUp = false;
    public GameObject winCanvas;

    public void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Won the game.");


                winCanvas.SetActive(true);
                Invoke(nameof(BackToMainMenu), 10);
                Destroy(this.gameObject);
            }



        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

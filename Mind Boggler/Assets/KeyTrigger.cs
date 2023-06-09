using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        canPickUp = true;


    }
    public bool canPickUp = false;
    public string Keyname;
    public void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerContoller.Keys += Keyname;
                Destroy(this.gameObject);
            }



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (playerContoller.Keys.Contains(Keyname))
        {
            playerContoller.Keys.Replace(Keyname, string.Empty);
            Destroy(GateObject, 1);
        }


    }
    public string Keyname;
    public GameObject GateObject;
}

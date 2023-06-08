using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Calculate movemonet direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        //Apply movement with speed to the character's position
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}

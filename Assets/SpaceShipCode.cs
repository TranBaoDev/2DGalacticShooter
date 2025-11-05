using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SpaceShip Code
public class SpaceShipCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component and set its velocity.
        // This makes the object move to the left immediately when it is initialized.
        GetComponent<Rigidbody2D>().velocity = Vector3.left * 10.0f;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
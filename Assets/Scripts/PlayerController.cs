using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody component from the object.
        playerRigidbody = GetComponent<Rigidbody>();
        // Add physics to the player, letting it jump upwards.
        playerRigidbody.AddForce(Vector3.up * 500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

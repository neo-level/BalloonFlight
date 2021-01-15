﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce;
    public float gravityModifier;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody component from the object.
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Adds physics to the player allowing an upwards jump.
            // Immediately applies force. using the impulse mode.
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

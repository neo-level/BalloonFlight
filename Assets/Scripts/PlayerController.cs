using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

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
        // Check if space is pressed and if the player is on the ground.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // Adds physics to the player allowing an upwards jump.
            // Immediately applies force. using the impulse mode.
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // The player is in the air so set boolean to false.
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // When the player collides with the ground set back to true.
        isOnGround = true;
    }
}
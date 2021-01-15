﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;

    public ParticleSystem explosionParticleSystem;
    
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");


    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody component from the object.
        _playerRigidbody = GetComponent<Rigidbody>();
        // Gets the Animator component from the object.
        _playerAnimator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed and if the player is on the ground.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Adds physics to the player allowing an upwards jump.
            // Immediately applies force. using the impulse mode.
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Trigger the Jump animation once the space bar has been pressed.
            _playerAnimator.SetTrigger(JumpTrig);


            // The player is in the air so set boolean to false.
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if the player collides with the ground or an obstacle.
        if (collision.gameObject.CompareTag(tag: "Ground"))
        {
            // When the player collides with the ground set back to true.
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag(tag: "Obstacle"))
        {
            // When player collides with the obstacle, its game over.
            gameOver = true;
            Debug.Log("Game over!");

            // Set the death boolean to true. Enabling the animation.
            _playerAnimator.SetBool(DeathB, true);

            // Set the integer corresponding with the correct death animation.
            _playerAnimator.SetInteger(DeathTypeINT, 1);
            
            // Once the player hits the obstacle, play the explosion particle.
            explosionParticleSystem.Play();
            
        }
    }
}
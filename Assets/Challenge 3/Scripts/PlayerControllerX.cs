using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private float _floatForce = 20.0f;
    private float _gravityModifier = 1.5f;
    
    private Rigidbody _playerRb;
    private BoundaryX _boundaryXScript;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource _playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    // Added public audio clip as a placeholder for the audio file.
    public AudioClip boingSound;
    private float _bounceForce = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= _gravityModifier;
        _playerAudio = GetComponent<AudioSource>();

        // Get the rigidbody component.
        _playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        
        // Get the players script component.
        _boundaryXScript = GameObject.Find("Player").GetComponent<BoundaryX>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && _boundaryXScript.isLowEnough)
        {
            _playerRb.AddForce(Vector3.up * _floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            // Addition of the "boing" sound when hitting the ground.
            _playerAudio.PlayOneShot(boingSound, volumeScale: 5.0f);
            
            // When hitting the ground bounce back.
            _playerRb.AddForce(Vector3.up * _bounceForce, ForceMode.Impulse);

        }
    }
}
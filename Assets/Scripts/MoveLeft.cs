using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30.0f;
    private PlayerController _playerControllerScript;
    private float _leftBoundary = -15.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the players script component.
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        // If the boolean game over is false continue to make the objects move.
        if (!_playerControllerScript.gameOver)
        {
            // Move the object to the left on a time base.
            transform.Translate(Vector3.left * (Time.deltaTime * _speed));
        }

        // Check if an obstacle object crosses the set boundary, if so destroy the object.
        if (transform.position.x < _leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
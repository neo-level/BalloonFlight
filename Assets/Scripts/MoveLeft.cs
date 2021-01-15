using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30.0f;
    private PlayerController _playerControllerScript;

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
    }
}
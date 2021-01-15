using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Set the startposition to the original position of the background.
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset position if the background removes a certain distance.
        if (transform.position.x < -50)
        {
            // Set the position of the backround back to its original values.
            transform.position = _startPosition;
        }
    }
}
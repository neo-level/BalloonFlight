using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float _repeatWidth;
    private Vector3 _startPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get the x width of the box collider from the object and divide it by half.
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        
        // Set the startposition to the original position of the background.
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset position if the background removes a certain distance.
        if (transform.position.x < _repeatWidth)
        {
            // Set the position of the background back to its original values.
            transform.position = _startPosition;
        }
    }
}
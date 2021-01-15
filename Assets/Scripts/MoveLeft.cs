using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 30.0f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // Move the object to the left on a time base.
        transform.Translate(Vector3.left * (Time.deltaTime * _speed));
    }
}
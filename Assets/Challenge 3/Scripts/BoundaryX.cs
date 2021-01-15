using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using UnityEngine.Serialization;

public class BoundaryX : MonoBehaviour
{
    private float _topBoundary;
    public bool isLowEnough = true;
    private float _bounceForce = 10.0f;

    private Rigidbody _playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        // Set top boundary based on the background y size.
        _topBoundary = GameObject.Find("Background").GetComponent<BoxCollider>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _topBoundary)
        {
            isLowEnough = false;
            SetBoundary(_topBoundary);
            _playerRigidbody.AddForce(Vector3.down * _bounceForce, ForceMode.Impulse);
        }
        else if (transform.position.y < _topBoundary)
        {
            isLowEnough = true;
        }
    }

    private void SetBoundary(float threshold)
    {
        transform.position = new Vector3(x: transform.position.x, y: threshold, z: transform.position.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

public class BoundaryX : MonoBehaviour
{
    private float _topBoundary;
    private float _bottomBoundary = -10f;

    // Start is called before the first frame update
    void Start()
    {
        _topBoundary = GameObject.Find("Background").GetComponent<BoxCollider>().size.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _topBoundary )
        {
            SetBoundary(_topBoundary);
        }
        else if (transform.position.y < _bottomBoundary)
        {
            SetBoundary(_bottomBoundary);
        }
    }
    
    private void SetBoundary(float threshold)
    {
        transform.position = new Vector3(x: transform.position.x, y: threshold, z: transform.position.z);
    }
}
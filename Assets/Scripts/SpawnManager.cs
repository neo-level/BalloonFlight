using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 _spawnPosition = new Vector3(25, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Create instance of the obstacle object and apply its location and rotation.
        Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Input;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Fixed spawning postion for the obstacles.
    private Vector3 _spawnPosition = new Vector3(25, 0, 0);

    // Set the time when to start spawning and at what rate.
    private float _startDelay = 2.0f;
    private float _repeatRate = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Spawn obstacles on an interval base.
        InvokeRepeating(methodName: nameof(SpawnObstacle),time: _startDelay,repeatRate: _repeatRate);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Spawns an obstacle everytime it's called.
    private void SpawnObstacle()
    {
        // Create instance of the obstacle object and apply its location and rotation.
        Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
    }
}
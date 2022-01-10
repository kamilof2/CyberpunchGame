using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField] float spawnRate = 1f;
    float nextTimeToSpawn = 0;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }

    }
}

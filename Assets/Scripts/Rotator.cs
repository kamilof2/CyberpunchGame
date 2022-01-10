using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotationZ;
    [SerializeField] private float rotationSpeed = 5;
    private float min, max;

    void Update()
    {
        rotationZ -= Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}

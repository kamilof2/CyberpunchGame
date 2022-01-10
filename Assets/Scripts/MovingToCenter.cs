using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToCenter : MonoBehaviour
{ 
    public float moveSpeed = 1f;
    Vector3 moveVector;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, moveSpeed * Time.deltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100f;
    public float playerMaxHealth = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerHealth);
    }

    public void Damage(float value)
    {
        playerHealth -= value;
        if (playerHealth <= 0)
        {
           FindObjectOfType<GameManager>().GameOver();
        }
    }
}

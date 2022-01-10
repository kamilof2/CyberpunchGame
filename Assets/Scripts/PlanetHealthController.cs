using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlanetHealthController : MonoBehaviour
{
    public float planetHealth = 100f;
    public float planetMaxHealth = 100f;
    public bool isShieldOn;

    Vector3 cameraInitialPosition;
    public Camera camera;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;


    private void Start()
    {
        
        isShieldOn = false;
    }
    public void ShakeIt()
    {
        cameraInitialPosition = camera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {

        float camerashakingOffsetX = UnityEngine.Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float camerashakingOffsetY = UnityEngine.Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = camera.transform.position;
        cameraIntermediatePosition.x += camerashakingOffsetX;
        cameraIntermediatePosition.y += camerashakingOffsetY;
        camera.transform.position = cameraIntermediatePosition;
    }
    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        camera.transform.position = cameraInitialPosition;
    }

    public void getDamage(float damage)
    {
        planetHealth -= damage;

        ShakeIt();
        if (planetHealth <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

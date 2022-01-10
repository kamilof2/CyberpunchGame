using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public PlayerController playCtrl;
    public PlanetHealthController planetCtrl;
    public GameManager gameManager;
    public Slider planetSlider;
    public Slider playerSlider;


    void Update()
    {
        playerSlider.value = playCtrl.playerHealth / playCtrl.playerMaxHealth;
        planetSlider.value = planetCtrl.planetHealth / planetCtrl.planetMaxHealth;

       
            

    }
}

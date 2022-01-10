using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public PlanetEffectSpawner planetEffect;
    public PlanetHealthController planetCtrl;
    public Laser laser;

   

    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 30f;
    bool isCooldown1 = false;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 20f;
    bool isCooldown2 = false;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 10;
    bool isCooldown3 = false;

    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4= 0.2f;
    bool isCooldown4 = false;

    private FMOD.Studio.EventInstance laserSFX;


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 100;
        abilityImage2.fillAmount = 100;
        abilityImage3.fillAmount = 100;
        abilityImage4.fillAmount = 100;
        laserSFX = FMODUnity.RuntimeManager.CreateInstance("event:/Laser");
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput();
        ManageCooldown();
    }

    private void ManageInput()
    {
        var input = Input.inputString;
        switch (input)
        {
            case "1":
                {
                    if(!isCooldown1)
                    {
                        planetEffect.PlayEffect(1);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Ring");
                        isCooldown1 = true;
                        abilityImage1.fillAmount = 1;
                    }
                    break;
                }
            case "2":
                {
                    if (!isCooldown2)
                    {
                        planetEffect.PlayEffect(2);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Heal");
                        isCooldown2 = true;
                        abilityImage2.fillAmount = 1;
                    }
                    break;
                }
            case "3":
                {
                    if (!isCooldown3)
                    {
                        planetEffect.PlayEffect(3);
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Shield");
                        isCooldown3 = true;
                        abilityImage3.fillAmount = 1;
                    }
                    break;
                }
            case "4":
                {
                    if (!isCooldown4)
                    {
                        laserSFX.start();
                        laser.playLaser = true;
                        isCooldown4 = true;
                        abilityImage4.fillAmount = 1;
                    }          
                    break;
                }
        }        
    }
 
    public void ManageCooldown()
    {
        if(isCooldown1)
        {
            abilityImage1.fillAmount -= 1 /  cooldown1 * Time.deltaTime ;

            if (abilityImage1.fillAmount <= 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/CoolDownEnd");
                abilityImage1.fillAmount = 1;
                isCooldown1 = false;
                
            }
        }
        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/CoolDownEnd");
                abilityImage2.fillAmount = 1;
                isCooldown2 = false;
                
            }
        }
        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilityImage3.fillAmount <= 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/CoolDownEnd");
                abilityImage3.fillAmount = 1;
                isCooldown3 = false;
                planetCtrl.isShieldOn = false;
                
            }
        }
        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;
            if (abilityImage4.fillAmount <= 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/CoolDownEnd");
                abilityImage4.fillAmount = 1;
                isCooldown4 = false;
                laserSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                laser.playLaser = false;


            }
        }
    }
}

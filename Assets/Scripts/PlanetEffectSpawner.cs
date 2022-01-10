using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEffectSpawner : MonoBehaviour
{
    public GameObject effect;
    public Transform effectPoint;
    public PlanetHealthController planetCtrl;
    public float fireForece;
    [SerializeField] float shrinkSpeed;
    GameObject projectile;
    Laser laser;

    public void PlayEffect(int id)
    {
        switch(id.ToString())
        {
            case "1":
                {
                    projectile = Instantiate(effect, effectPoint.position, Quaternion.identity);
                    break;
                }
            case "2":
                {
                    planetCtrl.planetHealth = 100f; 
                    break;
                }
            case "3":
                {
                    planetCtrl.isShieldOn = true;
                    break;
                }
            case "4":
                {
                    
                    break;
                }
        }
        
       

    }
   
}

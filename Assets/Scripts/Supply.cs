using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{
    public string supplyName;


    private void Update()
    {
       float dist = Vector3.Distance(transform.position, Vector3.zero);
       if(dist <= 3)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") || collision.CompareTag("Player"))
        {
            
           switch(supplyName)
            {
                case "healthPlanet":
                    {
                        FindObjectOfType<PlanetHealthController>().planetHealth += 20f; 
                        break;
                    }
                case "healthPlayer":
                    {
                        FindObjectOfType<PlayerController>().playerHealth += 20f;
                        break;
                    }
            }
            FMODUnity.RuntimeManager.PlayOneShot("event:/Health");
            Destroy(this.gameObject);
        }
    }

}

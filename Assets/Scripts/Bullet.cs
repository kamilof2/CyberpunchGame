using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    float damage = 10f;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Asteroid"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/HitAsteroid");
            Destroy(this.gameObject);
            collision.GetComponent<ObstacleController>().GetDamage(damage);
        }
    }
 }

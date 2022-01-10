using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1f;
    Vector3 moveVector;
    ScoreManager scManager;
    public bool isBig;
    SpawnObstacles sObstacle;
    float smallHealth = 20f, bigHealth = 50f;
    float asteroidHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        
        scManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        sObstacle = GameObject.FindGameObjectWithTag("ObstacleSpawn").GetComponent<SpawnObstacles>();
        if (isBig)
            asteroidHealth = bigHealth;
        else
            asteroidHealth = smallHealth;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, moveSpeed * Time.deltaTime);
        checkHealth();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = isBig == true ? 20.0f : 10.0f;
        if (collision.CompareTag("Player"))
        {
          

            collision.GetComponent<PlayerController>().Damage(damage);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Planet"))
        {
            if(!collision.GetComponent<PlanetHealthController>().isShieldOn)
                collision.GetComponent<PlanetHealthController>().getDamage(damage-5.0f);
            Destroy(gameObject);
        }
 
    }

    void checkHealth()
    {
        if (asteroidHealth <= 0)
        {
            if (isBig)
            {
                sObstacle.spawnSmall(transform.position);

                Destroy(this.gameObject);
                scManager.addPoints(10);

            }
            else
            {
                Destroy(this.gameObject);
                scManager.addPoints(5);
            }

        }
    }
    private void OnDestroy()
    {
        if (isBig)
        {

            FMODUnity.RuntimeManager.PlayOneShot("event:/Explosion");
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/ExplosionSmall");
        }
    }

    public void GetDamage(float value)
    {
        asteroidHealth -= value;
    }
}

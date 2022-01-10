using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot");
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up* fireForce, ForceMode2D.Impulse);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

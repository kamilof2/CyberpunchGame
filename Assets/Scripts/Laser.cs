using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{

    public Transform laserFirepoint;
    public LineRenderer lineRenderer;
    public LayerMask layersToHit;
    public float radius;
    public Camera cam;
    

    Transform m_transform;
    public bool playLaser;
    // Start is called before the first frame update
    void Awake()
    {
        playLaser = false;
        m_transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (playLaser)
        {
            lineRenderer.enabled = true;
            FireLaser();
        }
        else
            lineRenderer.enabled = false;
            
    }
    public void FireLaser()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
      

        Vector3 direction = mousePos;
        direction.z = 0;
        
        RaycastHit2D hit = Physics2D.Raycast(laserFirepoint.position , direction.normalized,20, layersToHit);
        
        lineRenderer.SetPosition(0, laserFirepoint.position);
        lineRenderer.SetPosition(1, transform.up*100000); // mousePos



        //Debug.Log(hit.collider.tag);
        if (hit.collider != null && hit.collider.attachedRigidbody)
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Asteroid")
            {
                Destroy(hit.collider.gameObject);
            }
               
           //Destroy(hit.collider.gameObject);
        }
                


    }
    

}

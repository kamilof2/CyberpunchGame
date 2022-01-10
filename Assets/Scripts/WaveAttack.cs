using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    [SerializeField] float shrinkSpeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
        rb.transform.localScale += Vector3.one * shrinkSpeed * Time.deltaTime;
        if (rb.transform.localScale.x >= 1.33f)
        {
            Destroy(rb.gameObject);
        }
    }
}

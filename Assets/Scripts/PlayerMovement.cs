using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 600f;
    float movement = 0;
    public Weapon weapon;
    public PlanetEffectSpawner effectSpawner;
    private Vector2 mousePosition;
    public Camera camera;
    private Rigidbody2D rb;


    public Transform orb;
    public float radius;

    private Transform pivot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pivot = orb.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;

    }
    void ManageInput()
    {
        movement = Input.GetAxis("Horizontal");
        var input = Input.inputString;
        

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            weapon.Fire();
        }
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        ManageInput();
        
    }
    private void FixedUpdate()
    {
        //  Vector2 aimDirection = mousePosition - rb.position;
       // float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
       // rb.rotation = aimAngle;
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * movementSpeed * -Time.deltaTime);

        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.position = orb.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

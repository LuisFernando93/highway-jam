using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector] public Vector2 movement;
    [SerializeField] private PlayerShift playerShift;
    public float carSpeed = 10f;
    public float airplaneSpeed = 15f;
    private bool haltMovement = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
            
    }

    private void FixedUpdate()
    {
        if (!haltMovement & playerShift.IsCar())
        {
            CarMovement();
        } else if (!haltMovement & !playerShift.IsCar())
        {
            AirplaneMovement();
        }
    }
    private void CarMovement()
    {
        rb.MovePosition(rb.position + movement.normalized * (carSpeed * Time.fixedDeltaTime));
    }

    private void AirplaneMovement()
    {
        rb.MovePosition(rb.position + movement.normalized * (airplaneSpeed * Time.fixedDeltaTime));
    }
}

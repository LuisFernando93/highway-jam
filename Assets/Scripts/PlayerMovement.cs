using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private PlayerShift playerShift;
    [SerializeField] private PlayerGravity playerGravity;
    [SerializeField] private float carSpeed;
    [SerializeField] private float airplaneSpeed;
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
        if (playerGravity.IsFalling()) haltMovement = true; else haltMovement = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    protected Vector2 direction;
    public Transform flightTarget;
    Rigidbody2D rb;

    public void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            direction += Vector2.right;
        }
    }

    public virtual void FlightMovement()
    {
        rb.gravityScale = 0;
        rb.freezeRotation = false;
        rb.velocity = Vector2.zero;

        float xAxis = Input.GetAxis("Horizontal");
        Vector3 pos = flightTarget.position;

        // Move to point 
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);

        // Rotate with object
        rb.MoveRotation(rb.rotation + (-xAxis * rotationSpeed) * Time.deltaTime);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GetInput();
        FlightMovement();
    }
}

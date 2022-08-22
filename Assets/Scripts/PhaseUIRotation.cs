using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUIRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    private GameObject rotationPoint;
    private Vector2 mousePos;

    private void Start()
    {
        cam = Camera.main;
        rotationPoint = GameObject.FindWithTag("RotationPoint");
        rb = rotationPoint.GetComponent<Rigidbody2D>();
    }

    void PhaseToMouse()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void FixedUpdate()
    {
        PhaseToMouse();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMovement : MonoBehaviour
{
    PlayerFlightMovement flying;
    PlayerWalkingMovement walking;

    private void Start()
    {
        flying = GetComponent<PlayerFlightMovement>();
        walking = GetComponent<PlayerWalkingMovement>();
        flying.enabled = false;
        walking.enabled = true;
    }

    void MovementChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Movement changed");
            flying.enabled = !flying.enabled;
            walking.enabled = !walking.enabled;

            if (flying.enabled)
            {
                Debug.Log("Flying enabled");
            }
            else if (walking.enabled)
            {
                Debug.Log("Walking Enabled");
            }
        }
    }

    private void Update()
    {
        MovementChange();
    }
}

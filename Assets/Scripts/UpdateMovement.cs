using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMovement : MonoBehaviour
{
    PlayerFlightMovement flying;
    PlayerWalkingMovement walking;
    public bool currentlyWalking;
    public bool currentlyFlying;

    private void Start()
    {
        flying = GetComponent<PlayerFlightMovement>();
        walking = GetComponent<PlayerWalkingMovement>();
        flying.enabled = false;
        currentlyFlying = false;
        walking.enabled = true;
        currentlyWalking = true;
    }

    void MovementChange()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Movement changed");
            flying.enabled = !flying.enabled;
            currentlyFlying = !currentlyFlying;
            walking.enabled = !walking.enabled;
            currentlyWalking = !currentlyWalking;

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

    public void Update()
    {
        MovementChange();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMovement : MonoBehaviour
{
    PlayerFlightMovement flying;
    PlayerWalkingMovement walking;
    public bool currentlyWalking;
    public bool currentlyFlying;
    public bool currentlyPhasing;

    private void Start()
    {
        flying = GetComponent<PlayerFlightMovement>();
        walking = GetComponent<PlayerWalkingMovement>();
        flying.enabled = false;
        currentlyFlying = false;
        walking.enabled = true;
        currentlyWalking = true;
        currentlyPhasing = false;
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

    void PhaseMovementChange()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //when walking you will be unable to move in any direction
            currentlyPhasing = true;
            walking.enabled = false;
        }
        if (currentlyFlying == false && currentlyPhasing == false)
        {
            //if you are not flying and you are not trying to "phase" Walking movement needs to be enabled
            walking.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //if Left Control key is not held down, you are no longer in the "Phase" transition
            currentlyPhasing = false;
        }
    }

    public void Update()
    {
        MovementChange();
        PhaseMovementChange();
    }
}

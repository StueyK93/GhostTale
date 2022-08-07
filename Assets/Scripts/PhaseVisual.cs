using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseVisual : MonoBehaviour
{
    private SpriteRenderer[] phase_SpR;
    private UpdateMovement uM;
    public bool targetDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        uM = GameObject.FindWithTag("Player").GetComponent<UpdateMovement>();
        phase_SpR = GetComponentsInChildren<SpriteRenderer>();
        foreach (var SpR in phase_SpR)
        {
            SpR.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPhaseTarget();
    }

    void DisplayPhaseTarget()
    {
        /* Look to include validation to change the target location depending on last input - L/R?
         * Make sure this is only able to be done if the player is still or include whilst moving? */

        /* Originally this did not work because I had not set the uM variable to look specifically at the 
         * player */

        if (uM.currentlyWalking)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                foreach (var SpR in phase_SpR)
                {
                    SpR.enabled = true;
                }
                targetDisplayed = true;
            }
            else foreach (var SpR in phase_SpR)
                {
                    SpR.enabled = false;
                    targetDisplayed = false;
                }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseVisual : MonoBehaviour
{
    private SpriteRenderer[] phase_SpR;

    // Start is called before the first frame update
    void Start()
    {
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
        /*
         * Look to include validation to change the target location depending on last input - L/R?
         * Make sure this is only able to be done if the player is still or include whilst moving?
         * Need to add a way to stop this from being accessible when flying - trying to add 
         * GetComponent<script>().enabled
         * will throw an Object Reference Exception so need to find a workaround
         */
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            foreach (var SpR in phase_SpR)
            {
                SpR.enabled = true;
            }
        }
        else foreach (var SpR in phase_SpR)
        {
                SpR.enabled = false;
        }
    }
}

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

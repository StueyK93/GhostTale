using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSwap : MonoBehaviour
{
    public GameObject plTa;
    private Transform phaseTarget;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plTa = GameObject.FindGameObjectWithTag("Phase Target");
        phaseTarget = plTa.transform;
    }

    void MakeSwap()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.LeftControl))
        {
                player.transform.position = phaseTarget;
            //this will not work, will need to take another look at this.
        }
    }
}

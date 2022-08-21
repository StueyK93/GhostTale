using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSwap : MonoBehaviour
{
    public GameObject plTa;
    public GameObject player;
    private UpdateMovement uM;

    private void Start()
    {
        uM = GetComponent<UpdateMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        plTa = GameObject.FindGameObjectWithTag("Phase Target");
    }

    void MakeSwap()
    {
        if (Input.GetKey(KeyCode.LeftControl) && uM.currentlyFlying == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.transform.position = plTa.transform.position;
            }
        }
    }

    /* Going to need to add a segment to make the phase UI and functionality be "stickied" to the mouse OR to be the set distance
     * Also, currently the player can end up within a collider, so  */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetActive(false);
    }


    private void Update()
    {
        MakeSwap();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
    private GameObject pl;
    private SpriteRenderer sp;
    private bool Ghost = false;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        sp = pl.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        ChangeStatus();
    }

    void ChangeStatus()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LowOpacity(0.5f);
            StartCoroutine(RestoreOpacity(1f));
        }
    }

    IEnumerator RestoreOpacity(float opacity)
    {
        if (Ghost == true)
        {
            yield return new WaitForSecondsRealtime(2);
            {
                Debug.Log("Return to normal");
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, opacity);
                Ghost = false;
            }
        }
    }

    private void LowOpacity(float opacity)
    {
        Debug.Log("Ghost Mode Enabled");
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, opacity);
        Ghost = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    public string[] cheatCode;
    private int index;

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        CheatCodeEntry();

    }

    void CheatCodeEntry()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == cheatCode.Length)
        {
            Debug.Log("Cheat entered");
            index = 0;
        }
    }
    
}

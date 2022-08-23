using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    public string[] cheatCode;
    private int index;
    public GameObject player;
    public GameObject hook;
    private SpringJoint2D sj2d;
    private UpdateMovement uM;
    private PlayerWalkingMovement pwm;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pwm = player.GetComponent<PlayerWalkingMovement>();
        uM = player.GetComponent<UpdateMovement>();
        sj2d = player.GetComponent<SpringJoint2D>();
        index = 0;
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheatCodeEntry();
        SlingShot();
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
            CheatStatus();
            index = 0;
        }
    }

    void CheatStatus()
    {
        sj2d.enabled = !sj2d.enabled;
        hook.GetComponent<Rigidbody2D>().simulated = !hook.GetComponent<Rigidbody2D>().simulated;
        uM.enabled = !uM.enabled;
        pwm.enabled = !pwm.enabled;
    }

    void SlingShot()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public Rigidbody2D rb;
    private bool isPressed = false;
    public float releaseTime;

    void OnMouseDown()
    {
        if (uM.enabled == false)
        {
            Debug.Log("Mouse Down");
            isPressed = true;
            rb.isKinematic = true;
            player.GetComponent<CircleCollider2D>().enabled = !player.GetComponent<CircleCollider2D>().enabled;
        }
    }
    void OnMouseUp()
    {
        if (uM.enabled == false)
        {
            isPressed = false;
            rb.isKinematic = false;
            StartCoroutine(Unhook());            
        }
    }

    IEnumerator Unhook()
    {
        yield return new WaitForSeconds(releaseTime);
        hook.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .5f, player.transform.position.z);
        CheatStatus();
        yield return new WaitForSeconds(releaseTime + .25f);
        player.GetComponent<CircleCollider2D>().enabled = !player.GetComponent<CircleCollider2D>().enabled;
    }
    
}

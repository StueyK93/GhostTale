using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItems : MonoBehaviour
{
    /* Currently this allows you to slingshot yourself across the screen, disabling colliders briefly and
     * re-enabling them after a brief delay.
     * The plan is for this to become applicable to items and object and not the Player.  Possibly work on a "possession" mechanic
     * that allows this to happen but never directly to the Player themself. 
     * there is a side effect that the slingshot can take into account current movement which just rockets it off further*/

    public GameObject player;
    private Rigidbody2D playerRb;

    public GameObject hook;
    private Rigidbody2D hookRb;

    private SpringJoint2D sj2d;

    private UpdateMovement uM;
    private PlayerWalkingMovement pwm;

    private bool isPressed = false;
    public float maximumDistance;
    public float releaseTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        hook = GameObject.FindGameObjectWithTag("RotationPoint");
        hookRb = hook.GetComponent<Rigidbody2D>();
        sj2d = player.GetComponent<SpringJoint2D>();
        uM = player.GetComponent<UpdateMovement>();
        pwm = player.GetComponent<PlayerWalkingMovement>();
    }
    private void Update()
    {
        SlingShot();
    }

    void SlingStatus()
    {
        sj2d.enabled = !sj2d.enabled;
        hookRb.simulated = !hookRb.simulated;
        uM.enabled = !uM.enabled;
        pwm.enabled = !pwm.enabled;
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        isPressed = true;
        playerRb.isKinematic = true;
        player.GetComponent<CircleCollider2D>().enabled = !player.GetComponent<CircleCollider2D>().enabled;
        SlingStatus();
    }

    void OnMouseUp()
    {
        isPressed = false;
        playerRb.isKinematic = false;
        StartCoroutine(Unhook());
    }

    void SlingShot()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, hookRb.position) > maximumDistance)
            {
                playerRb.position = hookRb.position + (mousePos - hookRb.position).normalized * maximumDistance;
            }
            else
                playerRb.position = mousePos;
        }
    }

    IEnumerator Unhook()
    {
        yield return new WaitForSeconds(releaseTime);
        hook.GetComponent<TrailRenderer>().enabled = true;
        hook.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .5f, player.transform.position.z);
        SlingStatus();
        yield return new WaitForSeconds(releaseTime + .25f);
        player.GetComponent<CircleCollider2D>().enabled = !player.GetComponent<CircleCollider2D>().enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hook.GetComponent<TrailRenderer>().enabled == true)
        {
            Debug.Log("Collided");
            hook.GetComponent<TrailRenderer>().enabled = false;
        }
    }

}

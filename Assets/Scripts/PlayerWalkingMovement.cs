using UnityEngine;

public class PlayerWalkingMovement : MonoBehaviour, IPlayerInputs
{ 
    [SerializeField]
    private float speed;
    protected Vector2 direction;
    Rigidbody2D rb;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public virtual void WalkingMovement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        rb.gravityScale = 1;
        rb.rotation = 0;
        rb.freezeRotation = true;

    }

    public void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            direction += Vector2.right;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        WalkingMovement();
        GetInput();
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D player;
    public float speed = 10.0f;
    public float jumpPower = 2.0f;
    bool isGrounded = false;
    bool isMoving = true;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jump();
        if (!isMoving && isGrounded)
        {
            player.velocity = Vector2.zero;
        }   
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(speed, player.velocity.y);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-speed, player.velocity.y);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public void Jump()
    {
        if(isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            player.velocity = new Vector2(player.velocity.x, jumpPower);
            isGrounded = false;
            isMoving = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("The COLLISION entered name is : " + collision.gameObject.name);
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}

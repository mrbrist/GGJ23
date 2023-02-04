using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    Vector2 movement;

    public SpriteRenderer PlayerSprite;

    public Sprite playerUp;
    public Sprite playerLeft;
    public Sprite playerRight;
    public Sprite playerDown;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.y == 1)
        {
            PlayerSprite.sprite = playerUp;
        }
        if(movement.y == -1)
        {
            PlayerSprite.sprite = playerDown;
        }

        if(movement.x == -1)
        {
            PlayerSprite.sprite = playerLeft;
        }
        if(movement.x == 1)
        {
            PlayerSprite.sprite = playerRight;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VegetableDrop")
        {
            collision.GetComponent<DropController>().isMovingToPlayer = true;
        }
    }
}

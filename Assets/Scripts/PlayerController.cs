using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    public float speed = 300f;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveInput();
    }

    void UpdateMoveInput()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir += Vector2.down;
        }

        if (moveDir != Vector2.zero)
        {
            spriteRenderer.flipX = (moveDir.x > 0);
            moveDir = moveDir.normalized;     
        }

        rb2d.velocity = (moveDir * Time.deltaTime * speed);

        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }
}

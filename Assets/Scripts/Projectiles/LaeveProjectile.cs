using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaeveProjectile : BaseProjectile
{
    SpriteRenderer playerSprite;
    public TrailRenderer trail;
    public bool fireOppo;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().spriteRenderer;

        if (playerSprite.flipX == false)
        {
            if (!fireOppo)
            {
                speed *= -1f;
                spriteRenderer.flipX = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();
        if (spriteRenderer.color.a < 1f) trail.emitting = false;

    }
    override protected void Movement()
    {
        rigidbody2d.velocity = direction * speed;
    }
}

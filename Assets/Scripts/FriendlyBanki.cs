using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBanki : MonoBehaviour
{
    public PlayerController playerController;
    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRender;
    Vector3 direction = Vector3.zero;
    float currTaskDuration = 0f;
    float currTaskMaxTime = 3f;
    public float speed = 5.25f;
    public void Init(PlayerController pc)
    {
        playerController = pc;
    }

    // Update is called once per frame
    void Update()
    {
        currTaskDuration += Time.deltaTime;

        if(currTaskDuration > currTaskMaxTime)
        {
            currTaskDuration = 0;
            currTaskMaxTime = Random.Range(1, 3);

            Vector3 randomness = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
            direction = (playerController.transform.position - transform.position) + randomness;
            direction = new Vector3(direction.x, direction.y, 0).normalized;

            spriteRender.flipX = (direction.x > 0);
        }

        rb2d.velocity = direction * Time.timeScale * speed;
    }
}

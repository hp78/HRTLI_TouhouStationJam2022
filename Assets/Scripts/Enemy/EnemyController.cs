using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyStats
    {
        public float health;
        public float speed;
        public float damage;

    }
    public SpriteRenderer spriteRenderer;
    public GameObject spriteHolder;
    public Rigidbody2D rigidbody2d;
    public Collider2D col;

    public Transform playertarget;

    public bool isDead = false;

    public EnemyStats enemyStats;

    /////////////////////////////////////////

    float flickerDuration;
    float colorDuration;


    // Start is called before the first frame update
    void Start()
    {
        playertarget = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (playertarget && !isDead)
        {
            ChasePlayer();
            Flicker();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (playertarget.position - this.transform.position).normalized;
        rigidbody2d.velocity = direction * enemyStats.speed;

        if (direction != Vector2.zero)
        {
            spriteRenderer.flipX = (direction.x > 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            float dmg = other.GetComponentInParent<BaseProjectile>().dmg;
            TakeDamage(dmg);
        }
    }

    void TakeDamage(float val)
    {
        enemyStats.health-= val;
        if(enemyStats.health<=0.0f)
        {
            PrepareToDie();
        }
        else
        {
            flickerDuration = 0.15f;
        }
    }

    void PrepareToDie()
    {
        isDead = true;
        spriteHolder.SetActive(false);
        col.enabled = false;
        StopAllCoroutines();
        Destroy(this.gameObject, 1f);
    }

    void Flicker()
    {
        if(flickerDuration >0.0f)
        {
            flickerDuration -= Time.deltaTime;

            if (spriteRenderer.color == Color.white)
                spriteRenderer.color = Color.red;

            else
                spriteRenderer.color = Color.white;

        }
        else
            spriteRenderer.color = Color.white;

    }
}


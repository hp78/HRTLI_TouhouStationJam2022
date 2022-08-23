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

    public GameObject expDrop;
    public GameObject expSucc;
    public int dropCount;

    /////////////////////////////////////////

    float flickerDuration;
    float colorDuration;


    // Start is called before the first frame update
    void Start()
    {
        var temp = GameObject.FindGameObjectWithTag("Player");
        if(temp)
        playertarget = temp.transform;

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
        Vector2 direction = (playertarget.position - this.transform.position);
        Vector2 directionNormalized = direction.normalized;

        if(direction.magnitude > 32)
        {
            rigidbody2d.velocity = directionNormalized * enemyStats.speed * 6;
        }
        else if (direction.magnitude > 16)
        {
            rigidbody2d.velocity = directionNormalized * enemyStats.speed * 1.5f;
        }
        else
        {
            rigidbody2d.velocity = directionNormalized * enemyStats.speed;
        }
        

        if (directionNormalized != Vector2.zero)
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
        if(enemyStats.health<=0.0f && !isDead)
        {
            isDead = true;
            PrepareToDie();
        }
        else
        {
            flickerDuration = 0.15f;
        }
    }

    void PrepareToDie()
    {
        spriteHolder.SetActive(false);
        col.enabled = false;

        float rand = Random.Range(0f, 100f);

        if(rand <=1f)
        {
            Instantiate(expSucc, new Vector3(this.transform.position.x + Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f),
                                this.transform.position.y + Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f),
                                    this.transform.position.z), Quaternion.identity);
        }

        for(int i = 0;  i<dropCount; ++i)
        {
            Instantiate(expDrop,new Vector3( this.transform.position.x + Random.Range(-transform.localScale.x/2f, transform.localScale.x / 2f),
                                this.transform.position.y + Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f),
                                    this.transform.position.z), Quaternion.identity);
        }
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


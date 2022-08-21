using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : BaseProjectile
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        direction = ((target.position + new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f),0f)) - this.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();
    }

    override protected void Movement()
    {
        rigidbody2d.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hp--;
            if(hp<=0f)
            {
                SetDie();
            }
        }
        
    }


}

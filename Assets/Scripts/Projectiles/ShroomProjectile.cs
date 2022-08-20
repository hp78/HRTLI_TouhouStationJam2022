using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomProjectile : BaseProjectile
{

    public GameObject pool;
    public Vector3 target;
    public Animator anim;
    float flickerDmgCDOn;
    float flickerDmgCDOff;

    bool reachedTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(this.transform.position.x + Random.Range(-3f, 3f),
                                this.transform.position.y + Random.Range(-3f, 3f),
                                    this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedTarget)
        {
            Duration();
            Pool();
            if(lifeDuration<0.0f)
            {
                pool.SetActive(false);
            }
        }
        else
            Movement();
    }

    override protected void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed *Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            reachedTarget = true;
            pool.SetActive(true);
            anim.enabled = false;
        }
    }
    void Pool()
    {
        if (flickerDmgCDOn < 0.0f)
        {
            col.enabled = true;
            flickerDmgCDOff -= Time.deltaTime;
            if (flickerDmgCDOff < 0.0f)
            {
                flickerDmgCDOn = .1f;
                col.enabled = false;
            }
        }
        else
        {
            flickerDmgCDOff = 0.1f;
            flickerDmgCDOn -= Time.deltaTime;
        }
    }
}

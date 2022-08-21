using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProjectile : BaseProjectile
{

    public Transform player;
    public Transform flareBall;
    public SpriteRenderer flaresprite;
    public float growspeedMod;
    float flickerDmgCDOn;
    float flickerDmgCDOff;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        growspeedMod = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();
        Flare();
        if(lifeDuration<0.0f)
        {
            if (flaresprite.color.a > 0f)
            {
                flaresprite.color -= new Color(0.0f, 0.0f, 0.0f, 1.5f * Time.deltaTime);
            }
        }
    }

    override protected void Movement()
    {
        this.transform.position = player.transform.position;
    }

    void Flare()
    {
        //flareBall.transform.localScale *= growspeedMod;
        flareBall.transform.localScale = new Vector3(
          flareBall.transform.localScale.x + growspeedMod,
          flareBall.transform.localScale.y + growspeedMod,
          flareBall.transform.localScale.z);
        if(flickerDmgCDOn < 0.0f)
        {
            col.enabled = true;
            flickerDmgCDOff -= Time.deltaTime;
            if(flickerDmgCDOff < 0.0f)
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

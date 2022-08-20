using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProjectile : BaseProjectile
{

    public Transform player;
    public Transform flareBall;
    public float growspeedMod;
   float flickerDmgCDOn;
    float flickerDmgCDOff;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        growspeedMod = growspeedMod * Time.deltaTime;
       
    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();
        Flare();

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
    public void Setduration(float val)
    {
        lifeDuration = val;
    }

  
}

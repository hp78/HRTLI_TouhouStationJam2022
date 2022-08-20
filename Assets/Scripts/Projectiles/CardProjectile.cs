using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProjectile : BaseProjectile
{

    public Transform center;

    public Animator anim;
    public TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(spriteRenderer.color.a<1f) trail.emitting = false;
    }

    override protected void Movement()
    {
        this.transform.position = center.transform.position;
    }

    public void EndofAnim()
    {
        trail.emitting = false;
        
        SetDie();
    }

}

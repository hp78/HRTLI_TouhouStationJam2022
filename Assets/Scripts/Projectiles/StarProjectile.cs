using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : BaseProjectile
{


    public Transform center;
    public TrailRenderer trail;

    Vector3 axis =Vector3.forward;
    public float radius;
    public float radiusSpeed;
    public bool negative = false;
    float scaleRad;
    // Start is called before the first frame update
    void Start()
    {
        if(negative)
        {
            speed *= -1f;
        }
        center = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();

        if(lifeDuration <0.0f)
        {
            trail.emitting = false;
        }
    }

    override protected void Movement()
    {
        scaleRad = (Mathf.PingPong(Time.time, radius)+1f);
        transform.RotateAround(center.position, axis, speed*100f * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * scaleRad + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}

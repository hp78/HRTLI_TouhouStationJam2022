using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadProjectile : BaseProjectile
{
    public Transform player;
    public Transform pad;
    public float growspeedMod;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        growspeedMod = speed;
        StartCoroutine(FadeAway());
    }

    // Update is called once per frame
    void Update()
    {
        Duration();
        Movement();
        KnockBack();
    }

    override protected void Movement()
    {
        this.transform.position = player.transform.position;
    }

    void KnockBack()
    {
        pad.transform.localScale = new Vector3(
          pad.transform.localScale.x + growspeedMod * Time.deltaTime,
          pad.transform.localScale.y + growspeedMod * Time.deltaTime,
          pad.transform.localScale.z);
    }
}

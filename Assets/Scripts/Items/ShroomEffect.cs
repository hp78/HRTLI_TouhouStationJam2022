using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomEffect : ItemEffect
{
    public Transform playerTf;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TimedEffect()
    {
        Debug.Log("Shroom Attack");
    }

    public override void PlayerHitEffect()
    {

    }
}

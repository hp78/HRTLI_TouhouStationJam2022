using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaStarEffect : ItemEffect
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
        Debug.Log("China Attack");
    }

    public override void PlayerHitEffect()
    {

    }
}

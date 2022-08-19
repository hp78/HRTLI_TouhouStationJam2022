using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEffect : ItemEffect
{
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
        Debug.Log("Knife Attack");
    }

    public override void PlayerHitEffect()
    {

    }
}

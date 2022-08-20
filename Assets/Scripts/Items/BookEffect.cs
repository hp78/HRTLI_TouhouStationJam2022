using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEffect : ItemEffect
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
        Debug.Log("Book Attack");
    }

    public override void PlayerHitEffect()
    {

    }
}

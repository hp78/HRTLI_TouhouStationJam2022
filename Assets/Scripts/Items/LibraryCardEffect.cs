using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCardEffect : ItemEffect
{
    public Transform playerTf;
    public GameObject CardProjectilePrefab;

    public Transform targetArrow;
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
        Debug.Log("LibraryCard Attack");
        FireCard();

    }

    public override void PlayerHitEffect()
    {

    }
    
    void FireCard()
    {
        GameObject obj = Instantiate(CardProjectilePrefab, this.transform.position, targetArrow.rotation);
        obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel]);
    }
}

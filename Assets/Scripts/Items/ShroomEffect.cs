using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomEffect : ItemEffect
{
    public Transform playerTf;
    public GameObject ShroomProjectilePrefab;

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
        FireShroom();
    }

    public override void PlayerHitEffect()
    {

    }

    void FireShroom()
    {
        for (int i = 0; i < itemStatsAtLevel[currLevel].effectCount; ++i)
        {
            GameObject obj = Instantiate(ShroomProjectilePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel], player.bonusStatModifier.passiveAtk);
        }
        audio.Play();


    }
}

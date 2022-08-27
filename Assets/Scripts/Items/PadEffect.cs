using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadEffect : ItemEffect
{
    public Transform playerTf;
    public GameObject padProjectilePrefab;
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
        FirePad();
    }

    public override void PlayerHitEffect()
    {
        float rand = Random.Range(0f, 100f);
        if (rand <= itemStatsAtLevel[currLevel].effectChance)
        {
            GameObject obj = Instantiate(padProjectilePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel], player.bonusStatModifier.passiveAtk);
            audio.Play();
        }

    }

    void FirePad()
    {

    }
}

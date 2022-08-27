using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEffect : ItemEffect
{
    public GameObject knifeProjectilePrefab;

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
        FireKnife();
    }

    public override void PlayerHitEffect()
    {

    }

    public void FireKnife()
    {
       for(int amt = 0; amt < itemStatsAtLevel[currLevel].effectCount; ++amt)
        {
            GameObject obj = Instantiate(knifeProjectilePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel], player.bonusStatModifier.passiveAtk);

        }
        audio.Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaevaEffect : ItemEffect
{
    public GameObject LaevaProjectilePrefab;

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
        FireLaeva();
    }

    public override void PlayerHitEffect()
    {

    }
    public void FireLaeva()
    {

          GameObject obj = Instantiate(LaevaProjectilePrefab, this.transform.position, Quaternion.identity);
          obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel]);
        if (currLevel == 5)
        {
            obj = Instantiate(LaevaProjectilePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel]);
            obj.GetComponent<LaeveProjectile>().fireOppo = true;

        }
        audio.Play();


    }
}

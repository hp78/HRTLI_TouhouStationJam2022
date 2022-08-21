using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GungnirEffect : ItemEffect
{

    public GameObject GungnirProjectilePrefab;

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
        Debug.Log("GungnirCard Attack");
        StartCoroutine(FireGungnir());


    }

    public override void PlayerHitEffect()
    {

    }

    IEnumerator FireGungnir()
    {
        for (int i = 0; i < itemStatsAtLevel[currLevel].effectCount; ++i)
        {
            GameObject obj = Instantiate(GungnirProjectilePrefab, this.transform.position, Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel]);
            yield return new WaitForSeconds(0.3f);
        }
        yield return 0;
    }
}

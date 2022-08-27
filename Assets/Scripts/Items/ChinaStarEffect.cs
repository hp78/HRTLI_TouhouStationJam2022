using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaStarEffect : ItemEffect
{
    public Transform playerTf;
    public GameObject StarProjectilePrefab;

    bool negative = false;
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
        StartCoroutine(FireStar());

    }

    public override void PlayerHitEffect()
    {

    }

    IEnumerator FireStar()
    {
        for (int i = 0; i < itemStatsAtLevel[currLevel].effectCount; ++i)
        {
            GameObject obj = Instantiate(StarProjectilePrefab, this.transform.position+ new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), this.transform.position.z), Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel], player.bonusStatModifier.passiveAtk);
            obj = Instantiate(StarProjectilePrefab, this.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), this.transform.position.z), Quaternion.identity);
            obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel],player.bonusStatModifier.passiveAtk);
            obj.GetComponent<StarProjectile>().negative = true;

            audio.Play();
            yield return new WaitForSeconds(0.5f);

        }

        yield return 0;
    }


}

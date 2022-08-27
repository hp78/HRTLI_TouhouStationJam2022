using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEffect : ItemEffect
{
    public Transform playerTf;
    public GameObject BookProjectilePrefab;

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
        FireBook();
    }

    public override void PlayerHitEffect()
    {

    }
    void FireBook()
    {
        GameObject obj = Instantiate(BookProjectilePrefab, this.transform.position, Quaternion.identity);
        obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel], player.bonusStatModifier.passiveAtk);
        audio.Play();
    }
}

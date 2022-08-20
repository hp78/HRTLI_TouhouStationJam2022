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
        Debug.Log("Book Attack");
        FireBook();
    }

    public override void PlayerHitEffect()
    {

    }
    void FireBook()
    {
        GameObject obj = Instantiate(BookProjectilePrefab, this.transform.position, Quaternion.identity);
        obj.GetComponent<BaseProjectile>().SetStats(itemStatsAtLevel[currLevel]);
        obj.GetComponent<BookProjectile>().Setduration(itemStatsAtLevel[currLevel].effectLife);
    }
}

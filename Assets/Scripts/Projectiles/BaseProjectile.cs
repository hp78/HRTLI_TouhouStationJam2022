using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2d;
    public Collider2D col;
    public Vector2 direction;

    public float speed;
    public float lifeDuration;

    public float dmg;
    public float hp;
    // Start is called before the first frame update

    virtual protected void Movement()
    {

    }

    protected void Duration()
    {
        lifeDuration -= Time.deltaTime;
        if(lifeDuration <0.0f)
        {
            SetDie();
        }
    }

    public void SetStats(ItemEffect.ItemStat itemStat)
    {
        dmg = itemStat.passiveAtk;
        hp = itemStat.passiveHp;
        speed = itemStat.passiveSpd;
    }

    protected void SetDie()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;
        Destroy(this.gameObject, 1f);
    }
}

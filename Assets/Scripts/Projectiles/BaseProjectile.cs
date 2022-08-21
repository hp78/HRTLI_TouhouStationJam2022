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
        dmg = itemStat.effectValue;
        hp = itemStat.effectHitLife;
        speed = itemStat.effectSpeed;
        lifeDuration = itemStat.effectLife;
    }

    public void SetDie()
    {
        StartCoroutine(FadeAway());
        col.enabled = false;
        Destroy(this.gameObject, 1.2f);
    }

    protected IEnumerator FadeAway(float val = 2.5f)
    {
        while(spriteRenderer.color.a >0f)
        {
            spriteRenderer.color -= new Color(0.0f, 0.0f, 0.0f, val * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }
}

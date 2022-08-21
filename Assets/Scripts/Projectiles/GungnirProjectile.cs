using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GungnirProjectile : BaseProjectile
{

    public List<Vector3> enemyPos;
    public TrailRenderer trail;
    public Animator anim;
    public SpriteRenderer shadow;

    // Start is called before the first frame update
    void Start()
    {
        shadow.enabled = false;
        spriteRenderer.enabled = false;
        StartCoroutine(SpearAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.color.a<1f) trail.emitting = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            enemyPos.Add(collision.transform.position);
        }
    }

    IEnumerator SpearAnim()
    {
        yield return new WaitForSeconds(.25f);
        if (enemyPos.Count == 0)
        {
            SetDie();

        }
        else 
        {
            anim.enabled = true;
            spriteRenderer.enabled = true;
            shadow.enabled = true;
            int rand = Random.Range(0, enemyPos.Count);
            this.transform.position = enemyPos[rand];
        }
    }


}

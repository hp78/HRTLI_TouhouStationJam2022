using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public struct BonusStat
    {
        public float passiveAtk;
        public float passiveDef;
        public float passiveSpd;
        public float passiveHp;
    }

    public Animator animator;
    public Rigidbody2D rb2d;

    public SpriteRenderer spriteRenderer;
    public Animator playerFacingAnimator;
    public Transform playerFacing;

    [Space(5)]
    public bool isAlive = true;
    public bool isInvul = false;
    public float invulDura = 0f;

    [Space(15)]
    public float currHealth;
    public float currMaxHealth;
    public float baseMaxHealth = 50;
    public float speed = 300f;

    [Space(10)]
    public int currLevel = 0;
    public float currXP = 0;
    public float nextXP;
    public float nextXPInterval = 100f;

    [Space(10)]
    public BonusStat bonusStatModifier;

    [Space(15)]
    public ItemEffect[] effects;

    // Start is called before the first frame update
    void Start()
    {
        currMaxHealth = baseMaxHealth;
        currHealth = baseMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveInput();
        UpdateItemEffects();
    }

    void UpdateMoveInput()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDir += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir += Vector2.down;
        }

        if (moveDir != Vector2.zero)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {

            }
            else
            {
                playerFacingAnimator.SetFloat("X", moveDir.x);
                playerFacingAnimator.SetFloat("Y", moveDir.y);

                spriteRenderer.flipX = (moveDir.x > 0);
            }

            moveDir = moveDir.normalized;
        }

        rb2d.velocity = (moveDir * Time.deltaTime * speed * (1 + bonusStatModifier.passiveSpd));

        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    void UpdateItemEffects()
    {
        foreach(ItemEffect ie in effects)
        {
            if (ie.TickTimer(Time.deltaTime))
                ie.TimedEffect();
        }
    }

    void RecalculateBonusStats()
    {
        bonusStatModifier.passiveAtk = 0;
        bonusStatModifier.passiveDef = 0;
        bonusStatModifier.passiveSpd = 0;
        bonusStatModifier.passiveHp = 0;

        //
        foreach (ItemEffect ie in effects)
        {
            bonusStatModifier.passiveAtk += ie.GetCurrLevelStat().passiveAtk;
            bonusStatModifier.passiveDef += ie.GetCurrLevelStat().passiveDef;
            bonusStatModifier.passiveSpd += ie.GetCurrLevelStat().passiveSpd;
            bonusStatModifier.passiveHp += ie.GetCurrLevelStat().passiveHp;
        }

        currMaxHealth = baseMaxHealth + bonusStatModifier.passiveHp;
    }

    void PickUpItem(int itemId)
    {
        effects[itemId].LevelUpItem();
    }

    void OnPlayerHit(float damageTaken)
    {
        // invul frams
        // vfx

        foreach(ItemEffect ie in effects)
        {
            ie.PlayerHitEffect();
        }
    }

    public void AddXP(float val)
    {
        currXP += val;

        // if level up
        if(currXP > nextXP)
        {
            currLevel++;
            nextXP += currLevel * nextXPInterval;

            LevelUp();
        }
    }

    void LevelUp()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("TAKING DMG");

            OnPlayerHit(1f);
        }
    }
}

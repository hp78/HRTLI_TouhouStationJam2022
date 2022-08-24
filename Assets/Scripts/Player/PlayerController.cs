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

    [Space(5)]
    public Animator animator;
    public Rigidbody2D rb2d;

    [Space(5)]
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

    [Space(5)]
    public GameObject bankiHeadPrefab;
    public int bankiCounter = 0;

    int currCoin = 0;
    int currUpgrade = 0;

    [Space(10)]
    public int currLevel = 1;
    public float currXP = 0;
    public float nextXP;
    public float nextXPInterval = 10f;

    [Space(10)]
    public BonusStat bonusStatModifier;

    [Space(15)]
    public ItemEffect[] effects;

    public AudioSource expSound;
    public AudioSource lvlSound;
    public AudioSource hitSound;
    public AudioSource dieSound;
    public AudioSource healSound;
    public AudioSource coinSound;

    public ParticleSystem healparticles;
    // Start is called before the first frame update
    void Start()
    {
        currCoin = PlayerPrefs.GetInt("Coin");
        currUpgrade = PlayerPrefs.GetInt("Upgrade");

        currMaxHealth = baseMaxHealth;
        currHealth = baseMaxHealth;

        //GameController.instance.hudControl.UpdateHPBar(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            UpdateMoveInput();
            UpdateItemEffects();
        }
    }

    void UpdateMoveInput()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDir += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDir += Vector2.right;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDir += Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A))
        {
            moveDir += Vector2.down;
        }

        if (moveDir != Vector2.zero)
        {
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
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

        rb2d.velocity = (moveDir * speed * (1 + bonusStatModifier.passiveSpd));

        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    void UpdateItemEffects()
    {
        foreach(ItemEffect ie in effects)
        {
            if (ie.TickTimer(Time.deltaTime))
            {
                ie.TimedEffect();

                for(int i = 0; i < bankiCounter; ++i)
                {
                    if(Random.Range(0f,100f) < 5f)
                    {
                        StartCoroutine(SupportBanki(i, ie));
                    }
                }
            }
        }
    }

    IEnumerator SupportBanki(int bCount, ItemEffect ie)
    {
        yield return new WaitForSeconds(0.1f * bCount);
        ie.TimedEffect();
    }

    void RecalculateBonusStats()
    {
        bonusStatModifier.passiveAtk = 0;
        bonusStatModifier.passiveDef = 0;
        bonusStatModifier.passiveSpd = 0;
        bonusStatModifier.passiveHp = 0;

        if (currUpgrade >= 1) bonusStatModifier.passiveHp = 25f;
        if (currUpgrade >= 2) bonusStatModifier.passiveSpd = 0.1f;
        if (currUpgrade >= 3) bonusStatModifier.passiveDef = 0.1f;
        if (currUpgrade >= 4) bonusStatModifier.passiveAtk = 0.1f;

        //
        foreach (ItemEffect ie in effects)
        {
            bonusStatModifier.passiveAtk += ie.GetCurrLevelStat().passiveAtk;
            bonusStatModifier.passiveDef += ie.GetCurrLevelStat().passiveDef;
            bonusStatModifier.passiveSpd += ie.GetCurrLevelStat().passiveSpd;
            bonusStatModifier.passiveHp += ie.GetCurrLevelStat().passiveHp;
        }

        currMaxHealth = baseMaxHealth + bonusStatModifier.passiveHp;

        GameController.instance.hudControl.UpdateHPBar(currHealth / currMaxHealth);
    }

    void OnPlayerHit(float damageTaken)
    {
        if (!isInvul)
        {
            currHealth -= damageTaken;
            GameController.instance.hudControl.UpdateHPBar(currHealth/currMaxHealth);

            if (currHealth < 0)
            {
                isInvul = true;
                StartCoroutine(Die());
            }
            else
            {
                isInvul = true;
                StartCoroutine(Invul());
            }
        }

        foreach(ItemEffect ie in effects)
        {
            ie.PlayerHitEffect();
        }
    }

    IEnumerator Invul()
    {
        hitSound.Play();
        float elapsed = 0f;
        {
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.black;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.black;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.black;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.black;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.04f);
            spriteRenderer.color = Color.white;
        }

        isInvul = false;
        yield return null;
    }

    IEnumerator Die()
    {
        isAlive = false;
        spriteRenderer.enabled = false;
        dieSound.Play();
        yield return new WaitForSeconds(1.0f);
        GameController.instance.deadMenu.SetActive(true);

        yield return null;
    }

    public void AddXP(float val)
    {
        currXP += val;
        expSound.Play();
        // if level up
        if (currXP > nextXP)
        {
            LevelUp();
        }
        GameController.instance.hudControl.UpdateXPBar(currXP / nextXP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            float dmg = collision.gameObject.GetComponent<EnemyController>().enemyStats.damage;
            float truedmg = dmg * (1-bonusStatModifier.passiveDef);
            if (truedmg <= 0.0f)
                OnPlayerHit(1f);
            else
                OnPlayerHit(truedmg);
        }
    }

    void LevelUp()
    {
        currXP -= nextXP;
        currLevel++;
        nextXP = currLevel * nextXPInterval;
        lvlSound.Play();
        GameController.instance.ShowLevelUpMenu();
        GameController.instance.hudControl.UpdateLevel(currLevel);
    }

    public void LevelUpItem(int itemEffectIndex)
    {
        effects[itemEffectIndex].LevelUpItem();
        GameController.instance.hudControl.UpdateItemSlot(itemEffectIndex, ref effects[itemEffectIndex]);
        RecalculateBonusStats();
    }

    public void HealPlayer(float val)
    {
        currHealth = Mathf.Clamp(currHealth + val, 0, currMaxHealth);
        GameController.instance.hudControl.UpdateHPBar(currHealth/currMaxHealth);

        // call heal fx
        healparticles.Play();
        healSound.Play();
    }

    public void HealPlayerMax()
    {
        currHealth = currMaxHealth;
        GameController.instance.hudControl.UpdateHPBar(1);

        // call heal fx
        healparticles.Play();
        healSound.Play();


    }

    public void SpawnHead()
    {
        GameObject go = Instantiate(bankiHeadPrefab, transform.position, Quaternion.identity);
        go.GetComponent<FriendlyBanki>().Init(this);
        ++bankiCounter;
        GameController.instance.hudControl.bankiCount.text = "" + (bankiCounter + 1);
    }

    public void AddCoin(int val)
    {
        currCoin += val;
        PlayerPrefs.SetInt("Coin", currCoin);
        coinSound.Play();
    }    
}

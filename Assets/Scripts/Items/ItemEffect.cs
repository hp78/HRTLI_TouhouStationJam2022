using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour
{
    [System.Serializable]
    public struct ItemStat
    {
        [Space(5)]
        public float effectValue;
        public float effectCount;
        public float effectHitLife;
        public float effectLife;
        public float effectSpeed;
        public float effectCooldown;
        public float effectChance;

        [Space(5)]
        public float passiveAtk;
        public float passiveDef;
        public float passiveSpd;
        public float passiveHp;

        [Space(5)]
        [Multiline]
        public string itemDesc;
    }

    public string itemName;
    public Sprite itemPic;
    public bool isOffensiveSkill = true;
    public float currTimer = 0f;

    [Space(5)]
    [Multiline]
    public string itemFlavorText;

    [Space(5)]
    public int currLevel = 0;
    public ItemStat[] itemStatsAtLevel;


    public bool TickTimer(float deltaTime)
    {
        if(isOffensiveSkill)
        {
            if (itemStatsAtLevel[currLevel].effectCooldown == 0)
                return false;

            currTimer -= deltaTime;
            if (currTimer < 0f)
            {
                currTimer += itemStatsAtLevel[currLevel].effectCooldown;

                return true;
            }
        }
        else
        {
            currTimer -= deltaTime;
        }
        return false;
    }

    public virtual void TimedEffect()
    {

    }

    public virtual void PlayerHitEffect()
    {

    }

    public ItemStat GetCurrLevelStat()
    {
        return itemStatsAtLevel[currLevel];
    }

    public void LevelUpItem()
    {
        currLevel += 1;
        if (currLevel > 5)
            currLevel = 5;
    }
}

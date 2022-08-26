using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public TMP_Text levelText;

    [Header("Player Stuff")]
    public Image expFillBar;
    public Image hpBar;

    [Header("Item Slots")]
    public int[] itemSlotEffectIndex = new int[10];
    public GameObject[] itemGameObj;
    public Image[] itemImages;
    public TMP_Text[] itemLevels;
    public TMP_Text bankiCount;
    public TMP_Text elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHPBar(float fillPercent)
    {
        hpBar.fillAmount = fillPercent;
    }
    public void UpdateXPBar(float fillPercent)
    {
        expFillBar.fillAmount = fillPercent;
    }

    public void UpdateLevel(int currLevel)
    {
        levelText.text = "LV " + currLevel;
    }

    public void UpdateItemSlot(int itemEffectIndex, ref ItemEffect ieRef)
    {
        if (itemEffectIndex >= 8) return;

        int i = 0;
        for (; i < itemSlotEffectIndex.Length; ++i)
        {
            if(itemSlotEffectIndex[i] == itemEffectIndex)
            {
                itemLevels[i].text = "" + ieRef.currLevel;

                return;
            }

            if(itemSlotEffectIndex[i] == -1)
            {
                break;
            }
        }

        if(i < itemSlotEffectIndex.Length)
        {
            itemSlotEffectIndex[i] = itemEffectIndex;
            itemGameObj[i].SetActive(true);
            itemImages[i].sprite = ieRef.itemPic;
            itemLevels[i].text = "" + ieRef.currLevel;
        }

    }
}

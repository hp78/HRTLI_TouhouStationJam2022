using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LevelUpMenuController : MonoBehaviour
{
    public PlayerController _playerController;

    public Button[] selectionBtns;
    public Image[] itemPic;
    public TMP_Text[] itemName;
    public TMP_Text[] descText;
    public TMP_Text[] flavText;
    int[] selectionIndexes = new int[3];

    const int itemCount = 6;
    const int miscCount = 3;
    public Sprite[] miscSprites = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        if (_playerController == null)
            _playerController = GameController.instance.playerController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshItems()
    {
        EventSystem.current.SetSelectedGameObject(null);

        selectionIndexes[0] = GetAvailItem0();
        selectionIndexes[1] = GetAvailItem1();
        selectionIndexes[2] = GetAvailItem2();

        RefreshItemDesc(0);
        RefreshItemDesc(1);
        RefreshItemDesc(2);
    }

    void RefreshItemDesc(int selectionIndex)
    {
        if(selectionIndexes[selectionIndex] < 5)
        {
            int index = selectionIndexes[selectionIndex];
            ItemEffect ie = _playerController.effects[index];

            itemPic[selectionIndex].sprite = ie.itemPic;
            itemName[selectionIndex].text = ie.itemName;
            descText[selectionIndex].text = ie.itemStatsAtLevel[ie.currLevel + 1].itemDesc;
            flavText[selectionIndex].text = ie.itemFlavorText;
        }
        else if (selectionIndexes[selectionIndex] == 6)
        {
            itemPic[selectionIndex].sprite = miscSprites[0];
            itemName[selectionIndex].text = "Food";
            descText[selectionIndex].text = "Heal HP";
            flavText[selectionIndex].text = "";
        }
        else if (selectionIndexes[selectionIndex] == 7)
        {
            itemPic[selectionIndex].sprite = miscSprites[1];
            itemName[selectionIndex].text = "Coin";
            descText[selectionIndex].text = "bling bling";
            flavText[selectionIndex].text = "";
        }
        else 
        {
            itemPic[selectionIndex].sprite = miscSprites[2];
            itemName[selectionIndex].text = "More Heads";
            descText[selectionIndex].text = "IDK";
            flavText[selectionIndex].text = "";
        }
    }

    int GetAvailItem0()
    {
        bool hasFound = false;
        int itemIndex = -1;
        while (!hasFound)
        {
            itemIndex = Random.Range(0, 9);
            if (itemIndex < itemCount)
            {
                if (_playerController.effects[itemIndex].currLevel < 5)
                {
                    hasFound = true;
                }
            }
        }
        return itemIndex;
    }

    int GetAvailItem1()
    {
        bool hasFound = false;
        int itemIndex = -1;
        while (!hasFound)
        {
            itemIndex = Random.Range(0, 9);
            if(selectionIndexes[0] != itemIndex)
            {
                if (itemIndex < itemCount)
                {
                    if (_playerController.effects[itemIndex].currLevel < 5)
                    {
                        hasFound = true;
                    }
                }
                else
                {
                    hasFound = true;
                }
            }
        }
        return itemIndex;
    }

    int GetAvailItem2()
    {
        bool hasFound = false;
        int itemIndex = -1;
        while (!hasFound)
        {
            itemIndex = Random.Range(0, 9);
            if (selectionIndexes[0] != itemIndex && selectionIndexes[1] != itemIndex)
            {
                if (itemIndex < itemCount)
                {
                    if (_playerController.effects[itemIndex].currLevel < 5)
                    {
                        hasFound = true;
                    }
                }
                else
                {
                    hasFound = true;
                }
            }
        }
        return itemIndex;
    }

    public void ButtonSelectUpgrade(int selectionIndex)
    {
        int upgradeIndex = selectionIndexes[selectionIndex];
        if(upgradeIndex < 5)
        {
            _playerController.LevelUpItem(upgradeIndex);
        }
        else if (upgradeIndex == 6)
        {
            _playerController.HealPlayerMax();
        }
        else if (upgradeIndex == 7)
        {
            // add coin
        }
        else if (upgradeIndex == 8)
        {
            _playerController.SpawnHead();
        }

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

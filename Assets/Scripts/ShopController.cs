using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ShopController : MonoBehaviour
{
    public Image fumoImage;
    public IntVal playerCoin;
    public IntVal currUpgrade;
    public TMP_Text coinTxt;
    public TMP_Text upgradeCost;

    public TMP_Text nextUpgradeText;
    public TMP_Text upgradeDescText;


    public string[] partNames;
    public string[] upgradeDesc;
    public int[] upgradeCosts;
    public Sprite[] fumoSprites;


    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerCoin();
        UpdateFumoImage();
        UpdateTexts();
    }

    void UpdateTexts()
    {
        nextUpgradeText.text = partNames[currUpgrade.val];
        upgradeDescText.text = upgradeDesc[currUpgrade.val];
        upgradeCost.text = "" +upgradeCosts[currUpgrade.val];
    }
    void UpdatePlayerCoin()
    {
        coinTxt.text = "" + playerCoin.val;
    }

    public void ButtonUpgrade()
    {
        if(playerCoin.val >= upgradeCosts[currUpgrade.val] && currUpgrade.val < 4)
        {
            playerCoin.val -= upgradeCosts[currUpgrade.val];
            currUpgrade.val += 1;
            UpdateTexts();
            UpdateFumoImage();
            coinTxt.text = "" + playerCoin.val;
        }
    }

    void UpdateFumoImage()
    {
        fumoImage.sprite = fumoSprites[currUpgrade.val];
    }
    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

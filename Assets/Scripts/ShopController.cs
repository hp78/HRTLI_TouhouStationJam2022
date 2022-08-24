using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ShopController : MonoBehaviour
{
    public Image fumoImage;
    //public IntVal playerCoin;
    //public IntVal currUpgrade;
    public TMP_Text coinTxt;
    public TMP_Text upgradeCost;

    public TMP_Text nextUpgradeText;
    public TMP_Text upgradeDescText;


    public string[] partNames;
    public string[] upgradeDesc;
    public int[] upgradeCosts;
    public Sprite[] fumoSprites;

    int currCoin = 0;
    int currUpgrade = 0;

    // Start is called before the first frame update
    void Start()
    {
        currCoin = PlayerPrefs.GetInt("Coin");
        currUpgrade = PlayerPrefs.GetInt("Upgrade");


        UpdatePlayerCoin();
        UpdateFumoImage();
        UpdateTexts();
    }

    void UpdateTexts()
    {
        nextUpgradeText.text = partNames[currUpgrade];
        upgradeDescText.text = upgradeDesc[currUpgrade];
        upgradeCost.text = "" +upgradeCosts[currUpgrade];
    }
    void UpdatePlayerCoin()
    {
        coinTxt.text = "" + currCoin;
    }

    public void ButtonUpgrade()
    {
        if(currCoin >= upgradeCosts[currUpgrade] && currUpgrade < 4)
        {
            currCoin -= upgradeCosts[currUpgrade];
            currUpgrade += 1;
            UpdateTexts();
            UpdateFumoImage();
            coinTxt.text = "" + currCoin;

            PlayerPrefs.SetInt("Coin", currCoin);
            PlayerPrefs.SetInt("Upgrade", currUpgrade);
        }
    }

    void UpdateFumoImage()
    {
        fumoImage.sprite = fumoSprites[currUpgrade];
    }
    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

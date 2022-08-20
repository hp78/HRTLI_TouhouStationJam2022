using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpMenuController : MonoBehaviour
{
    PlayerController _playerController;
    
    public Image[] itemPic;
    public TMP_Text[] itemName;
    public TMP_Text[] descText;
    public TMP_Text[] flavText;

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

    }
}

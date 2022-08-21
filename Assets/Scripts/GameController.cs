using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Hard References")]
    public static GameController instance;
    public PlayerController playerController;

    [Header("UI Elements")]
    public HUDController hudControl;
    public PauseMenuController pauseMenu;
    public LevelUpMenuController lvlUpMenu;

    [Space(5)]
    public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime * Time.timeScale;

        UpdatePauseKey();

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowLevelUpMenu();
        }
    }

    void UpdatePauseKey()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void ShowLevelUpMenu()
    {
        Time.timeScale = 0f;
        lvlUpMenu.gameObject.SetActive(true);
        lvlUpMenu.RefreshItems();
    }
}

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
    public GameObject deadMenu;

    bool isPaused = false;
    bool isLevelingup = false;

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
        hudControl.elapsedTime.text = string.Format("{00:00}:{1:00}", + (int)timeElapsed / 60 , + (((int)timeElapsed) % 60));

        UpdatePauseKey();

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    ShowLevelUpMenu();
        //}
    }

    void UpdatePauseKey()
    {
        //
        if(Input.GetKeyDown(KeyCode.Escape) && !isLevelingup)
        {
            isPaused = !isPaused;
            TogglePause(isPaused);
        }
    }

    public void Unpause()
    {
        isPaused = false;
        TogglePause(isPaused);
    }

    void TogglePause(bool isOn)
    {
        pauseMenu.gameObject.SetActive(isOn);
        
        //
        if (!isOn && !isLevelingup)
        {
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetToFirstButton();
            Time.timeScale = 0f;
        }
    }

    public void ShowLevelUpMenu()
    {
        Time.timeScale = 0f;
        lvlUpMenu.gameObject.SetActive(true);
        lvlUpMenu.RefreshItems();
        lvlUpMenu.SetSelectedButton();
        isLevelingup = true;
    }

    public void CloseLevelUpMenu()
    {
        isLevelingup = false;
        lvlUpMenu.gameObject.SetActive(false);

        if (!isPaused && !isLevelingup)
        {
            Time.timeScale = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    public EventSystem eventSystem;
    public Button resumeButton;

    public void SetToFirstButton()
    {
        eventSystem.SetSelectedGameObject(resumeButton.gameObject);
    }
    public void ButtonResume()
    {
        GameController.instance.Unpause();
    }

    public void ButtonMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}

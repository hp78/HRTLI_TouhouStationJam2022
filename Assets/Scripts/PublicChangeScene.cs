using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PublicChangeScene : MonoBehaviour
{
    public string _sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

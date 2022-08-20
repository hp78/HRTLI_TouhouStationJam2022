using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public string _sceneName;
    float elapsedTime = 0f;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 1)
                SceneManager.LoadScene(_sceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public PlayerController playerController;

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionChooser : MonoBehaviour
{
    public float cooldown;

    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartShit());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartShit()
    {


        float randx = Random.Range(-x, x);
        float randy = Random.Range(-y, y);
        this.transform.position = new Vector2(randx, randy);
        float randc = Random.Range(0, cooldown);
        yield return new WaitForSeconds(randc);
        StartCoroutine(StartShit());
        yield return 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTileRepos : MonoBehaviour
{
    public Transform playerTf;

    void Start()
    {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if ((playerTf.position.x - transform.position.x) > 51)
            transform.position += new Vector3(100, 0);

        if ((playerTf.position.x - transform.position.x) < -51)
            transform.position -= new Vector3(100, 0);

        if ((playerTf.position.y - transform.position.y) > 51)
            transform.position += new Vector3(0, 100);

        if ((playerTf.position.y - transform.position.y) < -51)
            transform.position -= new Vector3(0, 100);
    }
}

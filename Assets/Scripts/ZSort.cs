using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSort : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.1f);
    }
}

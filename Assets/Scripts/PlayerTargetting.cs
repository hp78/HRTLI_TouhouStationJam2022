using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetting : MonoBehaviour
{

    public Transform targetingDot;


    float horizontalInput;
    float verticalInput;
    Vector2 direction;
    Vector3 lastTargetPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;
        Targetting();

    }

    void Targetting()
    {
        if (((Input.GetButton("Horizontal")) || (Input.GetButton("Vertical"))))
            lastTargetPoint = new Vector3(direction.x, direction.y, 0.0f);

        targetingDot.position = transform.position + lastTargetPoint;
    }
}

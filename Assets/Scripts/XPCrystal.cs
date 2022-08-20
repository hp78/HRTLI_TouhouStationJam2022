using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPCrystal : MonoBehaviour
{
    public float xpAmount = 1f;
    public CircleCollider2D cCollider2d;
    //PlayerController _playerControl;

    bool isMoving = false;
    float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnCollect();
        }
    }

    IEnumerator MoveToPlayer()
    {
        while(elapsedTime < 1)
        {
            transform.position = Vector3.Lerp(transform.position, 
                GameController.instance.playerController.transform.position, 
                elapsedTime * 0.075f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        GameController.instance.playerController.AddXP(xpAmount);
        Destroy(gameObject);
    }

    void OnCollect()
    {
        cCollider2d.enabled = false;
        isMoving = true;
        StartCoroutine(MoveToPlayer());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPCrystal : MonoBehaviour
{
    public float xpAmount = 1f;
    public CircleCollider2D cCollider2d;
    //PlayerController _playerControl;
    Transform targetTF;

    bool isMoving = false;
    float elapsedTime = 0f;
    float collectTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        EventManager.Subscribe("XPSucc", OnCollect);
    }

    private void OnDisable()
    {
        EventManager.UnSubscribe("XPSucc", OnCollect);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("BankiHead"))
        {
            targetTF = collision.transform;
            OnCollect();
        }
    }

    IEnumerator MoveToPlayer()
    {
        while(elapsedTime < collectTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetTF.position, 
                elapsedTime * 0.075f * collectTime);
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
        collectTime = Random.Range(0.5f, 1.5f);
        StartCoroutine(MoveToPlayer());
    }
}

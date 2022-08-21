using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccCrystal : MonoBehaviour
{
    public CircleCollider2D cCollider2d;
    Transform targetTF;

    bool isMoving = false;
    float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("BankiHead"))
        {
            targetTF = collision.transform;
            OnCollect();
        }
    }

    IEnumerator MoveToPlayer()
    {
        while (elapsedTime < 1)
        {
            transform.position = Vector3.Lerp(transform.position, targetTF.position,
                elapsedTime * 0.075f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        EventManager.Send("XPSucc");
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    void OnCollect()
    {
        cCollider2d.enabled = false;
        isMoving = true;
        StartCoroutine(MoveToPlayer());
    }
}

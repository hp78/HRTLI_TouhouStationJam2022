using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public CircleCollider2D cCollider2d;
    Transform targetTF;

    bool isMoving = false;
    float elapsedTime = 0f;
    float collectTime = 1f;

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
        if (collision.CompareTag("Player"))
        {
            targetTF = collision.transform;
            OnCollect();
        }
    }

    IEnumerator MoveToPlayer()
    {
        while (elapsedTime < collectTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetTF.position,
                elapsedTime * 0.3f / collectTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        GameController.instance.playerController.HealPlayer(5);
        Destroy(gameObject);
    }

    void OnCollect()
    {
        cCollider2d.enabled = false;
        isMoving = true;
        collectTime = Random.Range(0.1f, 0.75f);
        StartCoroutine(MoveToPlayer());
    }
}

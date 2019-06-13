using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float lifeSpan;
    public float speed;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        transform.position += transform.up * -1f * Time.deltaTime * speed;
        if (timer > lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Destroy(gameObject, 0.03f);
        }
    }
}

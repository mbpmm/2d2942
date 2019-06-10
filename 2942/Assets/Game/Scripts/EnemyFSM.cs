using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        GoingToTarget,
        Function1,
        Last,
    }

    [SerializeField] private EnemyState state;

    public float speed;
    public float rotateSpeed;
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletDelay;
    public float timer;
    public float hp;

    public Transform target;
    private GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        timer = -6f;
        player = GameObject.Find("Player");
        target = player.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (state)
        {
            case EnemyState.GoingToTarget:
                Vector2 lookDir = (Vector2)transform.position - (Vector2)player.transform.position;
                lookDir.Normalize();
                float rotateAmount = Vector3.Cross(lookDir, transform.up*-1f).z;

                rb.angularVelocity = rotateSpeed * rotateAmount;
                rb.velocity = transform.up*-1f * speed;

                bulletDelay += Time.deltaTime;

                if (bulletDelay > 1.2f)
                {
                    GameObject auxBullet;
                    auxBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);

                    bulletDelay = 0;
                }
                break;
            case EnemyState.Function1:
                timer += Time.deltaTime;
                float y = Mathf.Cos(timer*2f)*1.5f;
                transform.position = new Vector2(timer,y);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "spitfire")
        {
            hp = 0;
        }
    }
}
using System;
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
    public GameObject bullet2;
    public GameObject explosion;
    public float bulletDelay;
    public float bulletTime;
    public float timer;
    public float hp;
    public Transform target;

    private float screenLimit;
    private SpriteRenderer spriteRend;
    private GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        screenLimit = 6f;
        timer = -6f;
        player = GameObject.Find("Player");
        target = player.transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
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

                if (bulletDelay > 3f)
                {
                    GameObject auxBullet;
                    auxBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);

                    bulletDelay = 0;
                }
                break;
            case EnemyState.Function1:
                timer += Time.deltaTime;
                float y = Mathf.Cos(timer*2f)*0.8f+2f;
                transform.position = new Vector2(timer,y);

                bulletDelay += Time.deltaTime;
                bulletTime = UnityEngine.Random.Range(2f, 4f);

                if (bulletDelay > bulletTime)
                {
                    GameObject auxBullet;
                    auxBullet = Instantiate(bullet2, bulletEmitter.transform.position, bulletEmitter.transform.rotation);

                    bulletDelay = 0;
                }
                break;
        }

        if (hp<=0)
        {
            Explode();
            
        }
        else if(transform.position.x>screenLimit)
        {
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        GameObject expAux;
        expAux = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            hp -= 10;
        }
        if (other.tag=="MissileExp")
        {
            Explode();
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
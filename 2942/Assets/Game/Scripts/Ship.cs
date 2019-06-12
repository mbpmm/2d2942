using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject explosion;
    public float energy;
    public int cantMissiles;
    private float damageReceived;
    void Start()
    {
        damageReceived = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject expAux;
        expAux = Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="BulletEnemy")
        {
            energy -= damageReceived;
            Debug.Log(energy);
        }
        if (collision.tag == "EPU")
        {
            energy += damageReceived;
            Debug.Log(energy);
        }
    }
}

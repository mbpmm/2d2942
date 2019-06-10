using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="BulletEnemy")
        {
            energy -= damageReceived;
            Debug.Log(energy);
        }
    }
}

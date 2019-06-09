using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float lifeSpan;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed;
    public float missileRotSpeed;
    private GameObject zeroPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        zeroPos = GameObject.Find("MissileExplosionPoint");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = (Vector2)zeroPos.transform.position;
        lookDir.Normalize();
        float rotateAmount = Vector3.Cross(lookDir, transform.up).z;

        rb.angularVelocity = missileRotSpeed * rotateAmount;
        rb.velocity = transform.up*-1f * missileSpeed;
    }
}

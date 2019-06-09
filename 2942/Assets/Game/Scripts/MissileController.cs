using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed;
    public float missileRotSpeed;
    public GameObject cam;
    public CameraShake cameraShake;
    public GameObject explosion;
    private GameObject zeroPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraShake = cam.GetComponent<CameraShake>();
        zeroPos = GameObject.Find("MissileExplosionPoint");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = (Vector2)transform.position-(Vector2)zeroPos.transform.position;
        lookDir.Normalize();
        float rotateAmount = Vector3.Cross(lookDir, transform.up).z;

        rb.angularVelocity = missileRotSpeed * rotateAmount;
        rb.velocity = transform.up * missileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="MissileExpPoint")
        {
            StartCoroutine(cameraShake.Shake(.3f, .2f));
            GameObject expAux;
            expAux = Instantiate(explosion, zeroPos.transform.position, Quaternion.identity);
            Destroy(gameObject,.5f);
        }
    }
}

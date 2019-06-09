using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public float vertical;
    public float horizontal;
    public GameObject bullet;
    public GameObject missile;
    public GameObject bulletEmitter;
    private Rigidbody2D playerRB;
    private float limMax, limXMin, limYMin;
    public float fireRate;
    private float nextFire;
   
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        limMax = 0.96f;
        limXMin = 0.04f;
        limYMin = 0.07f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, vertical, 0);

        playerRB.velocity = movement * speed;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, limXMin, limMax);
        pos.y = Mathf.Clamp(pos.y, limYMin, limMax);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (Input.GetMouseButton(0)&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootMissile();
        }
    }

    void Shoot()
    {
        GameObject bulletAux;
        bulletAux = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
    }

    void ShootMissile()
    {
        GameObject missileAux;
        missileAux= Instantiate(missile, bulletEmitter.transform.position, Quaternion.Euler(0,0,0));
    }
}

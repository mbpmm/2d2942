using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public float vertical;
    public float horizontal;
    public GameObject bullet;
    public GameObject bulletPU;
    public GameObject missile;
    public GameObject bulletEmitter;
    public GameObject bulletEmitter2;
    public GameObject bulletEmitter3;
    public float fireRate;

    private float powerUpDuration;
    private bool powerUp;
    private Rigidbody2D playerRB;
    private float limMax, limXMin, limYMin; 
    private float nextFire;
    private Ship ship;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        ship = GetComponent<Ship>();
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
            if (powerUp)
                ShootPowerUp();
            else
                Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space)&&ship.cantMissiles>0)
        {
            ShootMissile();
            ship.cantMissiles--;
        }

        if (powerUp)
        {
            powerUpDuration += Time.deltaTime;
            if (powerUpDuration>8f)
            {
                powerUp = false;
                powerUpDuration = 0f;
            }
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

    void ShootPowerUp()
    {
        GameObject bulletAux;
        bulletAux = Instantiate(bulletPU, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
        GameObject bulletAux2;
        bulletAux2 = Instantiate(bulletPU, bulletEmitter2.transform.position, bulletEmitter3.transform.rotation);
        GameObject bulletAux3;
        bulletAux3 = Instantiate(bulletPU, bulletEmitter3.transform.position, bulletEmitter3.transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="SPU")
        {
            powerUp = true;
        }
    }
}

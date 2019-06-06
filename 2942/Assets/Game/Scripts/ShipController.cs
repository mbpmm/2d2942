using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public float vertical;
    public float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical") ;
        horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(transform.position.x * horizontal * Time.deltaTime * -1f * speed, transform.position.y * vertical * Time.deltaTime * -1f * speed);
    }
}

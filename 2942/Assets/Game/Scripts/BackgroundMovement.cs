using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed;
    MeshRenderer backRenderer;
    // Start is called before the first frame update
    void Start()
    {
        backRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        backRenderer.material.mainTextureOffset = offset;
    }
}

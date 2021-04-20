using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    private float spriteLength;
    private float startPositionY;

    public float speed;

    void Start()
    {
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.y;
        startPositionY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);

        if(transform.position.y <= startPositionY - spriteLength) transform.position = new Vector3(transform.position.x, startPositionY, transform.position.z);
    }
}

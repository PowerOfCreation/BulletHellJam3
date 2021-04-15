using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerScreenBoundary : MonoBehaviour
{
    private float spriteWidth;
    private float spriteHeight;

    void Start()
    {
        spriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        spriteHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    void LateUpdate()
    {
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, -ScreenBoundary.screenBoundary.x + spriteWidth, ScreenBoundary.screenBoundary.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -ScreenBoundary.screenBoundary.y + spriteHeight, ScreenBoundary.screenBoundary.y - spriteHeight);

        transform.position = newPosition;
    }
}

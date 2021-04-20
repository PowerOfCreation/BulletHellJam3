using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerScreenBoundary : MonoBehaviour
{
    private float spriteWidth;
    private float spriteHeight;

    private float bottomBorder = 5f - 3.85f;

    void Awake()
    {
       // ScreenBoundary.screenChanged += CalculateBottomBoundary;
    }

    /*void CalculateBottomBoundary()
    {
        (Camera.main.orthographicSize * (16f/9f))
    }*/

    void Start()
    {
        spriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        spriteHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    void LateUpdate()
    {
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, -ScreenBoundary.screenBoundary.x + spriteWidth, ScreenBoundary.screenBoundary.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -ScreenBoundary.screenBoundary.y + spriteHeight + bottomBorder, ScreenBoundary.screenBoundary.y - spriteHeight);

        transform.position = newPosition;
    }
}

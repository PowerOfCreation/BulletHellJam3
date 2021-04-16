using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToScreenSize : MonoBehaviour
{
    void Start()
    {
        ResizeSpriteToScreen();
        ScreenBoundary.screenChanged += ResizeSpriteToScreen;
    }

    void ResizeSpriteToScreen()
    {
        transform.localScale = new Vector3((Camera.main.orthographicSize * (16f/9f) * 2f) / GetComponent<SpriteRenderer>().bounds.size.x, 1f, 0);
    }

    void OnDestroy()
    {
        ScreenBoundary.screenChanged -= ResizeSpriteToScreen;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    public static Vector2 screenBoundary;

    private static Vector2 screenResolution;

    void Start()
    {
        UpdateScreenBoundary();
    }

    private void UpdateScreenBoundary()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            UpdateScreenBoundary();
        }
    }
}

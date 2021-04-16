using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenBoundary : MonoBehaviour
{
    public static Vector2 screenBoundary;

    private static Vector2 screenResolution;

    public static Action screenChanged;

    void Start()
    {
        UpdateScreenBoundary();
    }

    private void UpdateScreenBoundary()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenChanged?.Invoke();
    }

    void Update()
    {
        if(screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            UpdateScreenBoundary();
        }
    }
}

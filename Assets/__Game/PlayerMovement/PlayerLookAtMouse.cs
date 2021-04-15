using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    private Camera sceneCamera;

    public void Awake()
    {
        sceneCamera = Camera.main;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position, Vector3.forward);
    }
}

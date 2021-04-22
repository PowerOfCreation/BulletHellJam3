using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenuButton : MonoBehaviour
{
    public void Click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

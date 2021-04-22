using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu self;

    public static bool isEnabled = false;

    public bool isInSubMenu = false;

    public TMP_Text gameOverText;

    public static bool isGameOver = false;

    void Awake()
    {
        self = this;
        Hide();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isInSubMenu)
        {
            if(isEnabled) Hide(); else Show();
        }
    }

    public static void Show(bool gameOver = false)
    {
        isGameOver = gameOver;
        isEnabled = true;
        Time.timeScale = 0f;
        self.GetComponent<CanvasGroup>().alpha = 1f;
        self.GetComponent<CanvasGroup>().interactable = true;
        self.GetComponent<CanvasGroup>().blocksRaycasts = true;
    
        if(gameOver)
        {
            self.gameOverText.enabled = true;
        }
    }

    public static void Hide()
    {
        Time.timeScale = 1f;
        if(isGameOver) {isGameOver = false; SceneManager.LoadScene(1); }
        isEnabled = false;
        self.GetComponent<CanvasGroup>().alpha = 0f;
        self.GetComponent<CanvasGroup>().interactable = false;
        self.GetComponent<CanvasGroup>().blocksRaycasts = false;

        self.gameOverText.enabled = false;
    }
}

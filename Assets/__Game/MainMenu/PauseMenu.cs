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

        if(isGameOver)
        {
            if(GetComponent<CanvasGroup>().alpha < 0.95f)
            {
                GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
            }
            else
            {
                isEnabled = true;
                Time.timeScale = 0f;
                self.GetComponent<CanvasGroup>().alpha = 1f;
                self.GetComponent<CanvasGroup>().interactable = true;
                self.GetComponent<CanvasGroup>().blocksRaycasts = true;

            }
        }
    }

    public static void Show(bool gameOver = false)
    {
        isGameOver = gameOver;

        if(!isGameOver)
        {
            isEnabled = true;
            Time.timeScale = 0f;
            self.GetComponent<CanvasGroup>().alpha = 1f;
            self.GetComponent<CanvasGroup>().interactable = true;
            self.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
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

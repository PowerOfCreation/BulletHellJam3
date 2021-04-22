using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class MenuScreenHolder<T> : MonoBehaviour where T : MenuScreenHolder<T>
{
    public static CanvasGroup canvasGroup;
    public static T self;

    void Awake()
    {
        self = (T) this;
        canvasGroup = self.GetComponent<CanvasGroup>();
    }

    public static void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public static void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
}

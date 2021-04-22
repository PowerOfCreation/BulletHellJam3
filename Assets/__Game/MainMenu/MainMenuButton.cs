using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void Click()
    {
        HowToPlayHolder.Hide();
        CreditsHolder.Hide();
        OptionsHolder.Hide();
        MainMenuHolder.Show();
    }
}

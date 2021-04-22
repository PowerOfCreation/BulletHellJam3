using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    public void Click()
    {
        MainMenuHolder.Hide();
        CreditsHolder.Hide();
        OptionsHolder.Hide();
        HowToPlayHolder.Show();
    }
}

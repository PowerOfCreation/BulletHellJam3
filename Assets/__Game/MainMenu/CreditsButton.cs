using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public void Click()
    {
        HowToPlayHolder.Hide();
        MainMenuHolder.Hide();
        OptionsHolder.Hide();
        CreditsHolder.Show();
    }
}

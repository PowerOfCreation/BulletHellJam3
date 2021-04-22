using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void Click()
    {
        if(PauseMenu.self)
        {
            PauseMenu.self.isInSubMenu = false;
        }

        HowToPlayHolder.Hide();
        CreditsHolder.Hide();
        OptionsHolder.Hide();
        MainMenuHolder.Show();
    }
}

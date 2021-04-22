using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public void Click()
    {
        if(PauseMenu.self)
        {
            PauseMenu.self.isInSubMenu = true;
        }

        HowToPlayHolder.Hide();
        CreditsHolder.Hide();
        MainMenuHolder.Hide();
        OptionsHolder.Show();
    }
}

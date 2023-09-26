using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    public void SettingButton()
    {
        if (settingsPanel == settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CloseGameButton()
    {
        Application.Quit();
    }
}

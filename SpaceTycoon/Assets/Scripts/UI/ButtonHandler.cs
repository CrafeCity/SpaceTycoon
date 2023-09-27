using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject[] tutorial;

    int tutorialCount = 0;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.Find("astronaut").GetComponent<PlayerMovement>();

        tutorial[0].SetActive(true);
        tutorial[1].SetActive(true);

        tutorial[2].SetActive(false);
        tutorial[3].SetActive(false);
        tutorial[4].SetActive(false);

        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void TutorialButton()
    {
        if (tutorialCount == 0) 
        { 
            tutorialCount++;
            tutorial[1].SetActive(false);
            tutorial[2].SetActive(true);
        }
        else if (tutorialCount == 1)
        {
            tutorialCount++;
            tutorial[2].SetActive(false);
            tutorial[3].SetActive(true);
        }
        else if (tutorialCount == 2) 
        {
            tutorialCount++;
            tutorial[3].SetActive(false);
            tutorial[4].SetActive(true);
        }
        else if (tutorialCount == 3)
        {
            tutorial[0].SetActive(false);
        }
    }

    public void CloseButton()
    {
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void SettingButton()
    {
        if (settingsPanel == settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
            shopPanel.SetActive(false);
        }
    }

    public void CloseGameButton()
    {
        Application.Quit();
    }

    public void ShopButton()
    {
        if (shopPanel == shopPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }

    public void ForwardPointerDown()
    {
        playerMovement.verticalInputPhone = 1;
    }
    public void ForwardPointerUp()
    {
        playerMovement.verticalInputPhone = 0;
    }

    public void BackPointerDown()
    {
        playerMovement.verticalInputPhone = -1;
    }
    public void BackPointerUp()
    {
        playerMovement.verticalInputPhone = 0;
    }

    public void LeftPointerDown()
    {
        playerMovement.horizontalInputPhone = -1;
    }
    public void LeftPointerUp()
    {
        playerMovement.horizontalInputPhone = 0;
    }

    public void RightPointerDown()
    {
        playerMovement.horizontalInputPhone = 1;
    }
    public void RightPointerUp()
    {
        playerMovement.horizontalInputPhone = 0;
    }
}

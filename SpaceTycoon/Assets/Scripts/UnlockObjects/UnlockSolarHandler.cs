using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockSolarHandler : MonoBehaviour
{
    SoundManager soundManager;


    [SerializeField]
    GameObject firstSolarUnlock;
    [SerializeField]
    GameObject secondSolarUnlock;

    MoneyHandler moneyHandler;

    Vector3 beginPosition = new Vector3(4.5f, 0, -1.1f);

    public int unlockSolarStage = 0;

    TextMeshProUGUI costText;
    int cost = 2;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();

        transform.position = beginPosition;

        firstSolarUnlock.SetActive(false);
        secondSolarUnlock.SetActive(false);

        costText = GameObject.Find("SolarCostText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        costText.text = "$" + cost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //every time the player collides then it checks if the player has enough money and if so then it will unlock/active the SolarPanel 
        if (other.gameObject.tag == "Player")
        {
            if (moneyHandler.money < cost)
            {
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[2]);
            }

            //doing this so that it won't stay 0
            if (unlockSolarStage == 0)
            {
                unlockSolarStage++;
            }


            if (unlockSolarStage == 1 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(4.5f, 0, 0.75f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 3;
                unlockSolarStage++;

                firstSolarUnlock.SetActive(true);
            }
            else if (unlockSolarStage == 2 && moneyHandler.money >= cost)
            {
                moneyHandler.money -= cost;

                secondSolarUnlock.SetActive(true);
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);
                Destroy(gameObject);
            }
        }
    }
}

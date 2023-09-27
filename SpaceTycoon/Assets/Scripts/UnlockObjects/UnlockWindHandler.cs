using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockWindHandler : MonoBehaviour
{
    SoundManager soundManager;

    [SerializeField]
    GameObject firstWindUnlock;
    [SerializeField]
    GameObject secondWindUnlock;

    MoneyHandler moneyHandler;

    Vector3 beginPosition = new Vector3(6.5f, 0, -4.5f);

    public int unlockWindStage = 0;

    TextMeshProUGUI costText;
    int cost = 120;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();

        transform.position = beginPosition;

        costText = GameObject.Find("WindCostText").GetComponent<TextMeshProUGUI>();

        firstWindUnlock.SetActive(false);
        secondWindUnlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = "$" + cost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //every time the player collides then it checks if the player has enough money and if so then it will unlock/active the Dropper 
        if (other.gameObject.tag == "Player")
        {
            if (moneyHandler.money < cost)
            {
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[2]);
            }

            //doing this so that it won't stay 0
            if (unlockWindStage == 0)
            {
                unlockWindStage++;
            }


            if (unlockWindStage == 1 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(7.8f, 0, -4.5f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;

                cost = 150;
                unlockWindStage++;

                firstWindUnlock.SetActive(true);
            }
            else if (unlockWindStage == 2 && moneyHandler.money >= cost)
            {
                secondWindUnlock.SetActive(true);

                moneyHandler.money -= cost;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockDropperHandler : MonoBehaviour
{
    SoundManager soundManager;

    // all the stages of droppers you can unlock
    [SerializeField]
    GameObject firstDropperUnlock;
    [SerializeField]
    GameObject secondDropperUnlock;
    [SerializeField]
    GameObject tirthDropperUnlock;
    [SerializeField]
    GameObject fourthDropperUnlock;
    [SerializeField]
    GameObject fifthDropperUnlock;
    [SerializeField]
    GameObject sixthDropperUnlock;
    [SerializeField]
    GameObject seventhDropperUnlock;
    [SerializeField]
    GameObject eigthDropperUnlock;
    [SerializeField]
    GameObject ninthDropperUnlock;

    //money handler script
    MoneyHandler moneyHandler;

    //sets the position of the unlockDropperPad
    Vector3 beginPosition = new Vector3(-4.69999981f, 0, -6.92000008f);

    //the stages so that you can't unlock all at the same time
    public int unlockDropperStage = 0;

    TextMeshProUGUI costText;
    int cost = 0;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();

        transform.position = beginPosition;

        costText = GameObject.Find("DropperCostText").GetComponent<TextMeshProUGUI>();

        //sets all the droppers unactive
        firstDropperUnlock.SetActive(false);
        secondDropperUnlock.SetActive(false);
        tirthDropperUnlock.SetActive(false);
        fourthDropperUnlock.SetActive(false);
        fifthDropperUnlock.SetActive(false);
        sixthDropperUnlock.SetActive(false);
        seventhDropperUnlock.SetActive(false);
        eigthDropperUnlock.SetActive(false);
        ninthDropperUnlock.SetActive(false);
    }

    private void Update()
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
            if (unlockDropperStage == 0) 
            {
                unlockDropperStage++; 
            }


            if (unlockDropperStage == 1)
            {
                beginPosition = new Vector3(-1.7f, 0, -6.92f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                cost = 10;
                unlockDropperStage++;

                firstDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 2 && moneyHandler.money >= cost)
            {

                beginPosition = new Vector3(1.35f, 0, -6.92f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 30;
                unlockDropperStage++;

                secondDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 3 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(4.5f, 0, -6.92f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 60;
                unlockDropperStage++;

                tirthDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 4 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(-5.1f, 0, -6.13f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 100;
                unlockDropperStage++;

                fourthDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 5 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(-2.3f, 0, -6.13000011f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 150;
                unlockDropperStage++;

                fifthDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 6 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(-6.23f, 0, -1.18f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 210;
                unlockDropperStage++;

                sixthDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 7 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(-3f, 0, -1.18f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 280;
                unlockDropperStage++;

                seventhDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 8 && moneyHandler.money >= cost)
            {
                beginPosition = new Vector3(-0.55f, 0, -1.18f);
                transform.position = beginPosition;
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);

                moneyHandler.money -= cost;
                cost = 360;
                unlockDropperStage++;

                eigthDropperUnlock.SetActive(true);
            }
            else if (unlockDropperStage == 9 && moneyHandler.money >= cost)
            {
                moneyHandler.money -= cost;
                ninthDropperUnlock.SetActive(true);
                soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[1]);
                Destroy(gameObject);
            }
        }
    }
}

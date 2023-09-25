using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{

    //the text components
    TextMeshProUGUI uncollectedMoneyText;
    TextMeshProUGUI moneyText;


    //money
    public int uncollectedMoney = 0;
    public int money = 0;


    // Start is called before the first frame update
    void Start()
    {
        uncollectedMoneyText = GameObject.Find("UnCollectedMoney").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //updates the text in the gameobject(GUI)
        uncollectedMoneyText.text = uncollectedMoney.ToString();
        moneyText.text = money.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the player collides with moneypoint then the player will collect the money and can use it
        if (other.gameObject.tag == "Player")
        {
            money += uncollectedMoney;
            uncollectedMoney = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if the player exits the collider from moneypoint then the player will also collect the money and can use it
        if (other.gameObject.tag == "Player")
        {
            money += uncollectedMoney;
            uncollectedMoney = 0;
        }
    }
}

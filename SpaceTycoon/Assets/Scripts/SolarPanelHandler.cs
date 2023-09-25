using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelHandler : MonoBehaviour
{
    MoneyHandler moneyHandler;


    private void OnEnable()
    {
        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();

        if (gameObject.name == "SmallSolarPanels")
        {
            StartCoroutine(SmallSolarGenerator());
        }
        else if (gameObject.name == "BigSolarPanels")
        {
            StartCoroutine(BigSolarGenerator());
        }
    }

    IEnumerator SmallSolarGenerator()
    {
        yield return new WaitForSeconds(5);
        moneyHandler.uncollectedMoney += 1;

        StartCoroutine(SmallSolarGenerator());
    }

    IEnumerator BigSolarGenerator()
    {
        yield return new WaitForSeconds(5);
        moneyHandler.uncollectedMoney += 2;
        StartCoroutine(BigSolarGenerator());
    }
}

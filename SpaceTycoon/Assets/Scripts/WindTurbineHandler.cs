using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbineHandler : MonoBehaviour
{
    MoneyHandler moneyHandler;

    private void OnEnable()
    {
        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();

        if (gameObject.name == "SmallWindTurbines")
        {
            StartCoroutine(SmallWindGenerator());
        }
        else if (gameObject.name == "BigWindTurbines")
        {
            StartCoroutine(BigWindGenerator());
        }
    }

    IEnumerator SmallWindGenerator()
    {
        yield return new WaitForSeconds(5);
        moneyHandler.uncollectedMoney += 1;

        StartCoroutine(SmallWindGenerator());
    }

    IEnumerator BigWindGenerator()
    {
        yield return new WaitForSeconds(5);
        moneyHandler.uncollectedMoney += 2;
        StartCoroutine(BigWindGenerator());
    }
}

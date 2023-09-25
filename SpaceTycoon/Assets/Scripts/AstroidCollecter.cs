using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidCollecter : MonoBehaviour
{
    MoneyHandler moneyHandler;

    // Start is called before the first frame update
    void Start()
    {
        moneyHandler = GameObject.Find("MoneyPoint").GetComponent<MoneyHandler>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the astroid collides with the astroidcollecter then the astroid gets destroyed and will add 1 to uncollected money
        if (collision.gameObject.tag == "Astroid")
        {
            Destroy(collision.gameObject);
            moneyHandler.uncollectedMoney++;
        }
    }
}

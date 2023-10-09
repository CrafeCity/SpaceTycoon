using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelHandler : MonoBehaviour
{
    ColliderHandler colliderHandler;

    [SerializeField] GameObject fuelPanel;

    [SerializeField] GameObject floatingText;

    public float dropperFuel = 1f;
    public bool dropper = false;

    private void Start()
    {

        colliderHandler = GameObject.Find("astronaut").GetComponent<ColliderHandler>();

        floatingText.SetActive(false);
    }

    private void OnEnable()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Dropper"))
        {
            StartCoroutine(MinusFuel());
        }
    }

    // Update is called once per frame
    void Update()
    {
        FuelGUI();

        if (dropper)
        {
            colliderHandler.currentFuel = dropperFuel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        floatingText.SetActive(true);

        dropper = true;
    }

    private void OnTriggerExit(Collider other)
    {
        floatingText.SetActive(false);
        dropper = false;
    }

    void FuelGUI()
    {
        if (floatingText.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                fuelPanel.SetActive(true);
            }
        }
    }

    IEnumerator MinusFuel()
    {
        yield return new WaitForSeconds(5);
        dropperFuel -= 0.1f;
        StartCoroutine(MinusFuel());
    }

    public void AddFuel()
    {
        dropperFuel += 0.2f;
    }
}

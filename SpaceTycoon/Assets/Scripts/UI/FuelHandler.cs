using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelHandler : MonoBehaviour
{
    FuelHandler fuelHandler;

    GameObject fuelPanel;
    Slider fuelSlider;
    Image fuelFill;

    [SerializeField] GameObject floatingText;

    [SerializeField]float dropperFuel = 1f;

    private void Start()
    {
        fuelPanel = GameObject.Find("FuelPanel");
        fuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
        fuelFill = GameObject.Find("FuelFill").GetComponent<Image>();


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
        SliderColor();
        FuelGUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        floatingText.SetActive(true);

        fuelHandler = transform.Find("TriggerBox").GetComponent<FuelHandler>();
    }

    private void OnTriggerExit(Collider other)
    {
        floatingText.SetActive(false);
    }

    void FuelGUI()
    {
        if (floatingText.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                fuelPanel.SetActive(true);
            }

            if (fuelHandler != null)
            {
                fuelSlider.value = fuelHandler.dropperFuel;
            }
        }
    }

    void SliderColor()
    {

        if (fuelSlider.value >= 0.7f)
        {
            fuelFill.color = Color.green;
        }
        else if (fuelSlider.value < 0.7f && fuelSlider.value >= 0.5f)
        {
            fuelFill.color = new Color(255f / 255f, 165f / 255f, 0f);
        }
        else if (fuelSlider.value < 0.4f && fuelSlider.value >= 0.2f)
        {
            fuelFill.color = Color.yellow;
        }
        else if (fuelSlider.value < 0.2f)
        {
            fuelFill.color = Color.red;
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

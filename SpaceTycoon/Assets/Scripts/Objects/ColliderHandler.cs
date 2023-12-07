using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour
{
    public Slider fuelSlider;
    public float currentFuel = 1f;
    public bool addFuel = false;

    [SerializeField] Image fuelFill;
    [SerializeField] GameObject fuelPanel;


    private void Update()
    {
        fuelSlider.value = currentFuel;
        SliderColor();
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

    public void AddFuel()
    {
        addFuel = true;
    }

}
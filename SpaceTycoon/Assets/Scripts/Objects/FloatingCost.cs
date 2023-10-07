using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCost : MonoBehaviour
{
    Vector3 floatingDown = new Vector3(0, -0.5f, 0);
    Vector3 floatingUp = new Vector3(0, 0.5f, 0);
    Vector3 floatingCost;

    bool up = false;



    private void Update()
    {
        if (transform.localPosition.y > -0.3 && transform.localPosition.y < -0.1)
        {
            up = false;
        }
        else if (transform.localPosition.y > 0.1 && transform.localPosition.y < 0.3)
        {
            up = true;
        }

        if (transform.localPosition != floatingUp && !up)
        {
            floatingCost = Vector3.Lerp(transform.localPosition, floatingUp, Time.deltaTime * 0.5f);
        }
        else if (transform.localPosition != floatingDown && up)
        {
            floatingCost = Vector3.Lerp(transform.localPosition, floatingDown, Time.deltaTime * 0.5f);
        }

        transform.localPosition = floatingCost;
    }
}

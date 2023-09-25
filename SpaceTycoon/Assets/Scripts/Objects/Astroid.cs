using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // the positions where it needs to go
    Transform collectPoint;
    Transform collectPoint2;

    Transform checkPoint;
    Transform checkPoint2;

    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        //gets the transform of the gameobjects
        collectPoint = GameObject.Find("CollectPoint1").transform;
        collectPoint2 = GameObject.Find("CollectPoint2").transform;

        checkPoint = GameObject.Find("CheckPoint1").transform;
        checkPoint2 = GameObject.Find("CheckPoint2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        // when it starts it waits 2 seconds and then moves
        yield return new WaitForSeconds(2);

        // checks if the astroid is on the tird line
        if (transform.position.z > -1 && transform.position.x > -8.5)
        {
            newPosition = Vector3.Lerp(transform.position, checkPoint2.position, Time.deltaTime * 0.1f);
        }
        // checks if the astroid is on the second line
        else if (transform.position.z > -6 && transform.position.z < -1 && transform.position.x > -8.5)
        {
            newPosition = Vector3.Lerp(transform.position, checkPoint.position, Time.deltaTime * 0.1f);
        }
        // checks if the astroid is on the first line
        else if (transform.position.z < -6 && transform.position.x > -8.4)
        {
            // Calculate the new position based on interpolation
            newPosition = Vector3.Lerp(transform.position, collectPoint.position, Time.deltaTime * 0.1f);
        }
        else
        {
            newPosition = Vector3.Lerp(transform.position, collectPoint2.position, Time.deltaTime * 0.1f);
        }
        // Assign the new position to the asteroid
        transform.position = newPosition;
    }
}

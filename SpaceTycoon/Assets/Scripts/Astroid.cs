using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    Transform collectPoint;

    // Start is called before the first frame update
    void Start()
    {
        collectPoint = GameObject.Find("CollectPoint1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        yield return new WaitForSeconds(2);
        // Calculate the new position based on interpolation
        Vector3 newPosition = Vector3.Lerp(transform.position, collectPoint.position, Time.deltaTime * 0.1f);

        // Assign the new position to the asteroid
        transform.position = newPosition;
    }
}

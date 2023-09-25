using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperHandler : MonoBehaviour
{
    [SerializeField]
    Transform dropPoint;
    [SerializeField]
    GameObject astroid;

    private void OnEnable()
    {
        StartCoroutine(AstroidSpawner());
    }

    IEnumerator AstroidSpawner()
     {
        //waits 5 seconds and then spawns a clone it droppoint
        Vector3 dropPosition = dropPoint.position;
        yield return new WaitForSeconds(5);
        GameObject AstroidClone = Instantiate(astroid, dropPosition, Quaternion.identity);
        StartCoroutine(AstroidSpawner());
    }
}

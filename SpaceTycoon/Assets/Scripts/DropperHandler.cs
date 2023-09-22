using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperHandler : MonoBehaviour
{
    [SerializeField]
    Transform dropPoint;
    [SerializeField]
    GameObject astroid;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AstroidSpawner());
    }

     IEnumerator AstroidSpawner()
     {
         if (gameObject.activeSelf)
         {
            Vector3 dropPosition = dropPoint.position;
            yield return new WaitForSeconds(5);
            GameObject AstroidClone = Instantiate(astroid, dropPosition, Quaternion.identity);
            StartCoroutine(AstroidSpawner());
        }
     }
}

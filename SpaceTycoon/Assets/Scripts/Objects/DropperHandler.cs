using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperHandler : MonoBehaviour
{
    SoundManager soundManager;

    [SerializeField]
    Transform dropPoint;
    [SerializeField]
    GameObject astroid;

    private void OnEnable()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        StartCoroutine(AstroidSpawner());
    }

    IEnumerator AstroidSpawner()
     {
        //waits 5 seconds and then spawns a clone it droppoint
        Vector3 dropPosition = dropPoint.position;
        yield return new WaitForSeconds(5);
        GameObject AstroidClone = Instantiate(astroid, dropPosition, Quaternion.identity);
        soundManager.sfxAudioSource.PlayOneShot(soundManager.sfxClips[0]);
        StartCoroutine(AstroidSpawner());
    }
}

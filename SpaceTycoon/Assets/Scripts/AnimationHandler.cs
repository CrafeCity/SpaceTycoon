using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animatior;

    bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkAnimation();
    }

    void WalkAnimation()
    {
        // if wasd is pressed then walking variable is true
        if (Input.GetKey(KeyCode.W))
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        //connects the walking variable to the variable in the animator tab
        if (walking)
        {
            animatior.SetBool("Run", true);
        }
        else
        {
            animatior.SetBool("Run", false);
        }
    }
}

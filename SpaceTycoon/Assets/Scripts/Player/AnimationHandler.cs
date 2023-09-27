using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animatior;
    PlayerMovement playerMovement;

    bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
        if (Input.GetKey(KeyCode.W) || playerMovement.verticalInputPhone > 0.1f)
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.S) || playerMovement.verticalInputPhone < -0.1f)
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.A) || playerMovement.horizontalInputPhone > 0.1f)
        {
            walking = true;
        }
        else if (Input.GetKey(KeyCode.D) || playerMovement.horizontalInputPhone < -0.1f)
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

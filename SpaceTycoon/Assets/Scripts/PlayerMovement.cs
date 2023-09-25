using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float force = 2;
    [SerializeField]
    Transform rotationPoint;
    Transform playerCamera;

    Quaternion targetRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("CameraHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        CameraMovement();
    }

    void Movement()
    {
        //makes the player move acording to the rotationpoints direction
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = rotationPoint.forward * force;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -rotationPoint.forward * force;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -rotationPoint.right * force;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = rotationPoint.right * force;
        }
    }

    void Rotation()
    {
        // rotates the player towards the side they are wilking to using lerp
        if (Input.GetKey(KeyCode.W))
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            targetRotation = Quaternion.Euler(0, 180, 0);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 90, 0);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);
    }

    void CameraMovement()
    {
        // makes the follow the player using lerp
        Vector3 newCameraPosition = Vector3.Lerp(playerCamera.position, transform.position, Time.deltaTime * 5f);
        playerCamera.position = newCameraPosition;
        playerCamera.rotation = Quaternion.Euler(0, 0, 0);
    }
}

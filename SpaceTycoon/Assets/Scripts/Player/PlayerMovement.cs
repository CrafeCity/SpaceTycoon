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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if there's any input to avoid division by zero
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            Vector3 desiredDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(desiredDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    void CameraMovement()
    {
        // makes the follow the player using lerp
        Vector3 newCameraPosition = Vector3.Lerp(playerCamera.position, transform.position, Time.deltaTime * 5f);
        playerCamera.position = newCameraPosition;
        playerCamera.rotation = Quaternion.Euler(0, 0, 0);
    }
}

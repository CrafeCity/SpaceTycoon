using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform rotationPoint;
    Transform playerCamera;

    public float horizontalInputPhone = 0f;
    public float verticalInputPhone = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("CameraHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        CameraMovement();
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

        // Phone Rotataion
        if (Mathf.Abs(horizontalInputPhone) > 0.1f || Mathf.Abs(verticalInputPhone) > 0.1f)
        {
            Vector3 desiredDirection = new Vector3(horizontalInputPhone, 0, verticalInputPhone).normalized;
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

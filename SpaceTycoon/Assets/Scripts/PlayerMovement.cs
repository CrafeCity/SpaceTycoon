using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float force = 2;
    [SerializeField]
    Transform rotationPoint;
    Transform camera;

    Quaternion targetRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("CameraHolder").transform;
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
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = rotationPoint.forward * force;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -rotationPoint.forward * force;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -rotationPoint.right * force;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = rotationPoint.right * force;
        }
    }

    void Rotation()
    {

        if (Input.GetKey(KeyCode.W))
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 90, 0);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);
    }

    void CameraMovement()
    {
        Vector3 newCameraPosition = Vector3.Lerp(camera.position, transform.position, Time.deltaTime * 0.1f);
        camera.position = newCameraPosition;
        camera.rotation = Quaternion.Euler(0, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController : HumanoidController
{
    public float YDisplacement;
    public float mouseSpeed;
    private float xRot;
    public GameObject FPScamera;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        Movement();
        Turning();
    }

    private void Movement()
    {
        Vector2 desiredDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += new Vector3(desiredDirection.x * Time.deltaTime * speedMax, 0, desiredDirection.y * Time.deltaTime * speedMax);
    }

    private void Turning()
    {
        float mouseX = 0;
        float mouseY = 0;

        xRot -= mouseY;

        FPScamera.transform.localRotation = Quaternion.Euler(xRot, GetComponent<Camera>().transform.rotation.y, 0);
        gameObject.transform.Rotate(Vector3.up * mouseX);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;

    //references
    private Rigidbody rb;
    private Camera mainCamera;

    private Vector3 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ProccessInput();

        KeepPlayerOnScreen();

        RotateToFaceVelocity();
    }

    

    private void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero) return;

        rb.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void ProccessInput()

    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            //get touch pos in worldspace
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 WorldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            //get vector pointing away from touchpos, make sure there is no Z change and normalize
            movementDirection = transform.position - WorldPosition;
            movementDirection.z = 0;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        newPosition = ScreenWarpAround(newPosition, viewportPosition);

        transform.position = newPosition;
    }

    private static Vector3 ScreenWarpAround(Vector3 newPosition, Vector3 viewportPosition)
    {
        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        return newPosition;
    }

    private void RotateToFaceVelocity()
    {
        if (rb.velocity == Vector3.zero) return;

        Quaternion targetRotation =  Quaternion.LookRotation(rb.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(
            transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }
}

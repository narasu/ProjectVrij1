using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    
    private static PlayerLook instance;
    public static PlayerLook Instance
    {
        get
        {
            return instance;
        }
    }
#pragma warning disable 0649
    [SerializeField] private Transform playerBody;

    public Vector2 lookVector;

    [SerializeField] [Range(0, 5)] private float raycastDistance = 10f;

    [SerializeField] [Range(5, 20)] private float mouseSensitivity = 150f;
#pragma warning restore 0649

    private float xAxisClamp;

    private void Awake()
    {
        instance = this;
        LockCursor();
    }

    private void Update()
    {
        CameraRotation();
        /*
        if (racyast hit teh thing)
        {
            thing.Highlight();
        }
        else
        {
            thing.GotoNormal();
        }
        */
 
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance)) 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            hit.transform.gameObject.GetComponent<Interactable>()?.Highlight();

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void LockCursor()
    {
        //hides and locks cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        //set mouse movement values
        float mouseX = lookVector.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookVector.y * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }

        if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
    
}

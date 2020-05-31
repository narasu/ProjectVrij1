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

    private Interactable target;

    private void Awake()
    {
        instance = this;
        LockCursor();
    }

    private void Update()
    {
        CameraRotation();
        SetTarget(null);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance)) 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            SetTarget(hit.transform.GetComponent<Interactable>());
            //Debug.Log(target);
            hit.transform.gameObject.GetComponent<Interactable>()?.Highlight();

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.white);
            //Debug.Log("Did not Hit");
        }
    }

    private void CameraRotation()
    {
        //set mouse movement values
        float mouseX = lookVector.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookVector.y * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        //looking up
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }

        //looking down
        if (xAxisClamp < -60.0f)
        {
            xAxisClamp = -60.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(60.0f);
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

    private void SetTarget(Interactable i)
    {
        target = i;
    }

    public Interactable GetTarget()
    {
        return target;
    }

    private void LockCursor()
    {
        //hides and locks cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}

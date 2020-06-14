using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinyl : KeyItem
{
    [SerializeField] private Transform recordPlayerPin;
    [SerializeField] private float spinningSpeed = 3.0f;
    private bool unlocked = false;
    public Phone phone;
    private void Update()
    {
        //Spin the record :D
        if (unlocked)
        {
            transform.Rotate(new Vector3(0, spinningSpeed, 0));
        }
    }

    
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        //Put the record on the pin and remove rigidbody and movable components
        if (other == lockTrigger && !unlocked)
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Movable>()); //might be better to use enabled = false?
            transform.position = recordPlayerPin.position;
            transform.rotation = recordPlayerPin.rotation;
            unlocked = true;

            phone.Activate();
        }
    }
}

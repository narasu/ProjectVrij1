using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinyl : KeyItem
{
    [SerializeField] private Transform recordPlayerPin;
    [SerializeField] private float spinningSpeed = 3.0f;
    private bool unlocked = false;
    private void Update()
    {
        if (unlocked)
        {
            transform.Rotate(new Vector3(0, spinningSpeed, 0));
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other == lockTrigger && !unlocked)
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Movable>()); //in other use cases it might be better to use enabled = false
            transform.position = recordPlayerPin.position;
            transform.rotation = recordPlayerPin.rotation;
            unlocked = true;
        }
    }
}

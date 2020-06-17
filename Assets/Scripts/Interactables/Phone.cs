using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : KeyItem
{
    //private MeshRenderer meshRenderer;
    private Rigidbody rb;

    [SerializeField] private GameObject phoneAudio;
    private SwitchableAudio switchableAudio;
    private Movable movable;
    private KeyItem keyItem;


    private void Awake()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        rb = gameObject.GetComponent<Rigidbody>();
        movable = gameObject.GetComponent<Movable>();
        keyItem = gameObject.GetComponent<KeyItem>();

        //switchableAudio = GetComponent<SwitchableAudio>();

        rb.isKinematic = true;

        switchableAudio = phoneAudio.GetComponent<SwitchableAudio>();
        
    }

    private void Start()
    {
        movable.enabled = false;
        keyItem.enabled = false;
    }

    private void Update()
    {
        phoneAudio.transform.position = gameObject.transform.position;
    }

    public void Activate()
    {

        //gets enabled after timer elapsed
        //start playing sound using SwitchableAudio script
        switchableAudio.gameObject.SetActive(true);


        //activate physics and key
        movable.enabled = true;
        keyItem.enabled = true;
        rb.isKinematic = false;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other == lockTrigger)
        {
            Destroy(switchableAudio);
        }
    }
}

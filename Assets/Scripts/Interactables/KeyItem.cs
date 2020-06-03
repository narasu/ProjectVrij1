using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private Transform lockItem;
    [SerializeField] private Collider lockTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == lockTrigger)
        {
            lockItem.GetComponent<LockItem>()?.Unlock();
        }
    }
}

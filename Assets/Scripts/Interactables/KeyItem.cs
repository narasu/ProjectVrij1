using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] protected Transform lockItem;
    [SerializeField] protected Collider lockTrigger;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other == lockTrigger)
        {
            GetComponent<Movable>()?.Drop();
            Player.Instance.ClearHand();
            lockItem.GetComponent<LockItem>()?.Unlock();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Key for use in lock-and-key mechanic
public class KeyItem : MonoBehaviour
{
    [SerializeField][Tooltip("The object which this item will unlock")] protected Transform lockItem;
    [SerializeField][Tooltip("The trigger for this item to collide with")] protected Collider lockTrigger;
    
    //When this object interacts with its corresponding lock, unlock it and force-drop this key from the player's hand.
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

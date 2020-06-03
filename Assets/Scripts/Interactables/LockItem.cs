using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockItem : MonoBehaviour
{
    private bool unlocked = false;
    public void Unlock()
    {
        if (unlocked)
            return;

        Debug.Log("Unlocked");
        unlocked = true;
    }
}

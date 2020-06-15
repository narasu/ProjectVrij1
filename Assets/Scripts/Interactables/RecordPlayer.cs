using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : LockItem
{
    [SerializeField] private Phone phone;
    [SerializeField] private float unlockDelay = 5.0f;
    private float timer = 0f;

    protected override void Update()
    {
        base.Update();
        if (unlocked)
        {
            timer += Time.deltaTime;

            if (timer>unlockDelay)
            {
                phone.Activate();
            }
        }
        
    }
    /*
    public override void Unlock()
    {
        base.Unlock();
        StartCoroutine("ActivatePhone");
    }

    private IEnumerator ActivatePhone()
    {
        yield return new WaitForSeconds(unlockDelay);

        phone.Activate();
    }
    */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        
    }
   private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            Debug.Log("interessant");
            navMeshAgent.SetDestination(targetVector);
        }
    }

    private void Update()
    {
        if (navMeshAgent == null)
        {
            Debug.LogError("Not working m8");
        }
        else
        {
            SetDestination();
        }
    }

}

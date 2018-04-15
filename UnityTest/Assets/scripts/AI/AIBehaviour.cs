using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIBehaviour : MonoBehaviour {

    private GameObject destination;
    NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Start () {

        destination = GameObject.Find("Capital_Hall");
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
	}

    private void SetDestination()
    {
         if(destination != null)
        {
            navMeshAgent.SetDestination(destination.transform.position);
        }
    }

}

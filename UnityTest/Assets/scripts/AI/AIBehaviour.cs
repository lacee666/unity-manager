using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour {

    private Animator animator;
    private GameObject destination;
    private AIHolder aiHolder;
    private NavMeshAgent navMeshAgent;
    private float damage = 30;
    

	void Start () {
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();
        destination = GameObject.Find("Capital_Hall");
        animator = this.GetComponent<Animator>();
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

    // if AI collides with tower, it damages it
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Capital_Hall"))
        {
            other.GetComponentInChildren<EnemyHealth>().GetDamage(damage);
            aiHolder.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIBehaviour : MonoBehaviour {

    private Animator animator;
    private GameObject destination;
    private AIHolder aiHolder;
    private float damage = 30;
    NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Start () {
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();
        animator = this.GetComponent<Animator>();
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
    private void Update()
    {
       //animator.Play()
    }
    private void SetDestination()
    {
        if(destination != null)
        {
            
            navMeshAgent.SetDestination(destination.transform.position);
        }
    }

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

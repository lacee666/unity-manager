using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierAI : MonoBehaviour {

    // this contains the list of enemies
    private AIHolder aiHolder;
    private GameObject target;
    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    // when enemies are dead, soldier goes back to this point
    private GameObject middle;
    private Animator animator;

    private float damage = 10;
    private bool attacking = false;
    private bool running = false;
    //attack cooldown
    private float attackTime = 1.0f;
    private float attackPower = 15f;     
    

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();
        middle = GameObject.Find("Middle_Point");
        

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }
    void Update()
    {

        if (attacking)
        {
            animator.Play("attack");
            attackTime -= Time.deltaTime;
            AttackEnemy();
        }
        SetDestination();
        if(running && !attacking)
        {
            animator.Play("idle");
        }


        if(target == null)
        {
            running = false;
        }
        else
        {
            running = Vector3.Distance(target.transform.position, this.transform.position) < 0.5;
        }
        
    }
    // calculates the closest enemy from aiHolder.enemies, returns index
    private int FindSmallest()
    {
        GameObject go = aiHolder.enemies[0];
        int j = 0;
        for (int i = 1; i < aiHolder.enemies.Count; i++)
        {
            if(Vector3.Distance(go.transform.position, this.transform.position) > Vector3.Distance(aiHolder.enemies[i].transform.position, this.transform.position))
            {
                go = aiHolder.enemies[i];
                j = i;
            }
        }
        return j;
    }

    private void SetDestination()
    {
        if (AIWaveHandler.WaveHappening)
        {
            if(target == null)
            {
                try
                {

                    //target = aiHolder.enemies[Random.Range(0, aiHolder.enemies.Count - 1)];
                    int closest = FindSmallest();
                    target = aiHolder.enemies[closest];
                    //navMeshAgent.SetDestination(target.transform.position);
                }
                catch (System.Exception e)
                {

                }
            }
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            attacking = false;
            navMeshAgent.SetDestination(middle.transform.position);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            attacking = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target)
        {
            attacking = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            attacking = false;          
        }
    }
    public void AttackEnemy()
    {
        if (attackTime <= 0.0f)
        {
            if (target != null)
            {
                //attacking = true;
                Attack(target);
                attackTime = 1.0f;
            }
        }
    }

    public void Attack(GameObject enemy)
    {
       
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;
       if(enemyHealth != null)
        {
            enemyHealth.GetDamage(attackPower);
            if (enemyHealth.CurrentHealth <= 0)
            {
                animator.Play("walk");
                attacking = false;
                aiHolder.enemies.Remove(enemy);
            }
            else if (enemyHealth == null)
            {
                animator.Play("walk");
                attacking = false;
            }
        }
     
    }
   
}

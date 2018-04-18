using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierAI : MonoBehaviour {


    private AIHolder aiHolder;
    private float damage = 10;
    private bool attacking = false;
    private float attackTime = 1.0f;
    private float attackPower = 15f;
    private GameObject target;

    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    private GameObject middle;
    private Animator animator;
    private bool running = false;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();

        rb = this.GetComponent<Rigidbody>();
        middle = GameObject.Find("middle");
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();


        navMeshAgent = this.GetComponent<NavMeshAgent>();

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
        else
        {
            Debug.Log("walk");
            
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
                    int closest = FindSmallest();
                    //target = aiHolder.enemies[Random.Range(0, aiHolder.enemies.Count - 1)];
                    target = aiHolder.enemies[closest];
                    navMeshAgent.SetDestination(target.transform.position);
                }
                catch (System.Exception e)
                {

                }
                Debug.Log("Destination set to skeleton.");
            }
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            attacking = false;
            navMeshAgent.SetDestination(middle.transform.position);
            Debug.Log("Destination set to middle.");
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Attacking");
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
                attacking = true;
                Debug.Log("Can attack");
                Attack(target);
                attackTime = 1.0f;
            }
        }
    }
    public void Attack(GameObject enemy)
    {
       
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;
       
        enemyHealth.GetDamage(attackPower);
        if (enemyHealth.CurrentHealth <= 0)
        {
            animator.Play("walk");
            attacking = false;
            aiHolder.enemies.Remove(enemy);
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower4 : BuildingTower
{

    void Start()
    {
        attackPower = 200;
        level = 4;
        cost = 150;
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();
        bulletSpeed = 500f;
    }

    void Update()
    {

        if (attacking)
        {
            attackTime -= Time.deltaTime;
            AttackEnemy();

        }

    }
    public void AttackEnemy()
    {
        if (attackTime <= 0.0f)
        {
            //System.Random rnd = new System.Random();
            //int r = rnd.Next(enemies.Count);


            if (aiHolder.enemies.Count == 0)
            {
                return;
            }
            GameObject enemy = null;


            for (int i = 0; i < aiHolder.enemies.Count; i++)
            {
                if (Vector3.Distance(this.transform.position, aiHolder.enemies[i].transform.position) < 2.0f)
                {
                    enemy = aiHolder.enemies[i];
                    break;
                }
            }

            if (enemy != null)
            {
                attacking = true;
                Debug.Log("Can attack");
                Attack(enemy);
                attackTime = 1.0f;
            }
        }
    }
    public override void Upgrade()
    {
        Deselect();
    }
    public virtual void Attack(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position + new Vector3(0, 0.9f, 0);
        sphere.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        sphere.GetComponent<Renderer>().material.color = Color.black;
        sphere.AddComponent<Rigidbody>().AddForce((enemy.transform.position - this.transform.position).normalized * bulletSpeed);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(attackPower);
    }
  
}

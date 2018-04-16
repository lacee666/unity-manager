using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower2 : BuildingTower
{

    private float startTime;


    void Start()
    {
        level = 1;
        cost = 80;
        attackPower = 70;
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


            if(aiHolder.enemies.Count == 0)
            {
                return;
            }
            GameObject enemy = null;
          

            for(int i = 0; i < aiHolder.enemies.Count; i++)
            {
                if(Vector3.Distance(this.transform.position, aiHolder.enemies[i].transform.position) < 2.0f)
                {
                    enemy = aiHolder.enemies[i];
                    break;
                }              
            }

            if(enemy != null)
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
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("tower_lvl3");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingTower3>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
    public override void Attack(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position + new Vector3(0, 0.9f, 0);
        sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        sphere.AddComponent<Rigidbody>().AddForce((enemy.transform.position - this.transform.position).normalized * bulletSpeed);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(attackPower);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower2 : BuildingTower
{

    private float startTime;

    private void Awake()
    {
        cost = 80;
        upgradeCost = 80;
    }

    void Start()
    {
        level = 1;
        attackPower = 70;
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();
        bulletSpeed = 500f;
        bullet = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>().Find("bullet");
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

   
   
}

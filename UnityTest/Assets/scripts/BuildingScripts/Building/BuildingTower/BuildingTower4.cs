using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower4 : BuildingTower
{
    private void Awake()
    {
        cost = 150;
        upgradeCost = 150;
    }
    void Start()
    {
        attackPower = 135;
        level = 3;
        cost = 150;
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
 
  
}

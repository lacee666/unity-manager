using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower1 : BuildingTower {


    private List<GameObject> enemies;
    void Start()
    {
        enemies = new List<GameObject>();
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < list.Length; i++)
        {
            enemies.Add(list[i]);
        }
        level = 0;
        cost = 50;
        attackPower = 40;     
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
            System.Random rnd = new System.Random();
            int r = rnd.Next(enemies.Count);
            GameObject enemy = enemies[r];
 
            if(Vector3.Distance(this.transform.position, enemy.transform.position) < 2.0f)
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
        Building temp = bi.Find("tower_lvl2");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingTower2>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }

    public override void Attack(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position + new Vector3(0, 0.9f, 0);
        sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        sphere.AddComponent<Rigidbody>().AddForce((enemy.transform.position - this.transform.position).normalized * 450.0f);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(attackPower);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            attacking = true;
            if (attackTime <= 0.0f)
            {
                Debug.Log("Can attack");
                Attack(other.gameObject);
                attackTime = 1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {

        }
    }
    */
}

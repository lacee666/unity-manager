using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower1 : BuildingTower {

    private float startTime;
    private float attackTime = 0.0f;
    private bool attacking = true;
    void Start()
    {
        cost = 20;
        startTime = Time.time;

        
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime >= secondsOfUpdate)
        {

            startTime = Time.time;
        }
        if (attacking)
        {
            attackTime -= Time.deltaTime;
        }
        Debug.Log(attackTime);
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

    public virtual void Attack(GameObject enemy)
    {
        EnemyHealth enemyHealth;

        //GameObject go = Instantiate();
        Debug.Log("Attacking");
        enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position + new Vector3(0, 0.9f, 0);
        sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        sphere.AddComponent<Rigidbody>().AddForce((enemy.transform.position - this.transform.position).normalized * 450.0f);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(150.0f);
    }
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
}

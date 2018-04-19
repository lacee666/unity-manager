using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower : BaseBuilding {

    protected AIHolder aiHolder;
    protected Building bullet;
    protected bool attacking = true;
    protected float attackPower;
    protected float attackTime;
    protected float bulletSpeed;

    void Start()
    {
        upgradeCost = 80;
        
    }
    /*
    public virtual void Attack(GameObject enemy)
    {

    }
    */
    public override void OnDestruction()
    {

    }
    public override void OnCreation()
    {

    }
    public void Attack(GameObject enemy)
    {
        Debug.Log(enemy.name);
        EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>(); ;

        GameObject sphere = Instantiate(bullet.prefab, this.transform.position, Quaternion.identity) as GameObject;
        sphere.transform.position = this.transform.position + new Vector3(0, 0.9f, 0);
        sphere.GetComponent<Rigidbody>().AddRelativeForce((enemy.transform.position - this.transform.position).normalized * bulletSpeed);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(attackPower);
        if (enemyHealth.CurrentHealth <= 0)
        {
            aiHolder.enemies.Remove(enemy);
        }
    }
}

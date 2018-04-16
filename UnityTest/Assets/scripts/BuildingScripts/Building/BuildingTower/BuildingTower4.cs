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
    }

    void Update()
    {
        if (attacking)
        {
            attackTime -= Time.deltaTime;
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
        sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        sphere.AddComponent<Rigidbody>().AddForce((enemy.transform.position - this.transform.position).normalized * 450.0f);
        Destroy(sphere, 2.0f);
        enemyHealth.GetDamage(attackPower);
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

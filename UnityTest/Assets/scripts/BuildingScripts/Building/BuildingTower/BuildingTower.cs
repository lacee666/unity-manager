using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower : BaseBuilding {




    protected AIHolder aiHolder;
    protected bool attacking = true;
    protected float attackPower;
    protected float attackTime;
    protected float bulletSpeed;
    void Start()
    {

    }

    public virtual void Attack(GameObject enemy)
    {

    }
    public virtual void Upgrade()
    {

    }
}

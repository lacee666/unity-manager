using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorker : BaseBuilding
{

    void Start()
    {
        secondsOfUpdate = 3.0f;
    }

    public virtual void Upgrade()
    {

    }
    public override void OnDestruction()
    {
        playerResources.MaxCapacity -= 2;
    }

    public override void OnCreation()
    {
        playerResources.MaxCapacity += 2;
    }

}

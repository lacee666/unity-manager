using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorker : BaseBuilding
{
    void Start()
    {
        secondsOfUpdate = 3.0f;
        upgradeCost = 50;
        cost = 100;
    }

    public override void OnDestruction()
    {
        playerResources.MaxCapacity -= 1;
    }

    public override void OnCreation()
    {
        playerResources.MaxCapacity += 1;
    }
}

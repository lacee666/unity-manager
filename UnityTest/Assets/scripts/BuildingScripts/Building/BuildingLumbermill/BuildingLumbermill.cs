using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill : BaseBuilding {

    protected int generateWoodPerSecond;
    void Start()
    {
        secondsOfUpdate = 3.0f;
        upgradeCost = 60;
    }

    public override void OnDestruction()
    {
        
    }
    public override void OnCreation()
    {

    }
}

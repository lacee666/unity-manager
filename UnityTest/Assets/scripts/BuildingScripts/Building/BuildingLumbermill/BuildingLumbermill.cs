using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill : BaseBuilding {

    protected int generateWoodPerSecond;
    void Start()
    {
        secondsOfUpdate = 3.0f;
    }

    public virtual void Upgrade()
    {

    }
    public override void OnDestruction()
    {
        
    }
    public override void OnCreation()
    {

    }
}

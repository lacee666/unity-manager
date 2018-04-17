using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill4 : BuildingLumbermill {

    private float startTime;

    void Start()
    {
        level = 0;
        cost = 100;
        startTime = Time.time;
        generateWoodPerSecond = 7;
        secondsOfUpdate = 3.0f;

    }
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= secondsOfUpdate)
        {
            playerResources.Wood += generateWoodPerSecond;
            startTime = Time.time;
        }

    }
    public override void Upgrade()
    {
        Deselect();
    }

}

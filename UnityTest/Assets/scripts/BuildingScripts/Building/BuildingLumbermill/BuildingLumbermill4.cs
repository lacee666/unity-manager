using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill4 : BuildingLumbermill {

    private float startTime;
    private void Awake()
    {
        cost = 140;
    }
    void Start()
    {
        level = 3;
        startTime = Time.time;
        generateWoodPerSecond = 4;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower4 : BuildingTower
{

    private float startTime;

    void Start()
    {
        cost = 50;
        startTime = Time.time;


    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime >= secondsOfUpdate)
        {

            startTime = Time.time;
        }

    }

    public override void Upgrade()
    {
        Deselect();
    }
}

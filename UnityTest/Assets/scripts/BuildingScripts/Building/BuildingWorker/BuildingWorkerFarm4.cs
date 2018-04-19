using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm4 : BuildingWorker
{

    private float startTime;

    private void Awake()
    {
        cost = 200;
    }
    void Start()
    {
        level = 3;

        startTime = Time.time;
        generateGoldPerSecond = 15;
        secondsOfUpdate = 3.0f;

    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= secondsOfUpdate)
        {
            playerResources.Gold += generateGoldPerSecond;
            startTime = Time.time;
        }
       
    }

    public override void Upgrade()
    {
        Deselect();
    }
}
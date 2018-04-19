using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm4 : BuildingWorker
{

    private float startTime;
    // Use this for initialization
    void Start()
    {
        level = 3;
        cost = 130;
        startTime = Time.time;
        generateGoldPerSecond = 15;
        secondsOfUpdate = 3.0f;
        //Debug.Log("Level4 farm spawned.");
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
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
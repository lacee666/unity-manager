using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm4 : BuildingWorker
{

    private float startTime;
    // Use this for initialization
    void Start()
    {
        cost = 50;
        startTime = Time.time;
        generateGoldPerSecond = 1;

        Debug.Log("Level4 farm spawned.");
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm2 : BuildingWorker
{

    private float startTime;
    // Use this for initialization
    void Start()
    {
        cost = 20;
        startTime = Time.time;
        generateGoldPerSecond = 2;

        Debug.Log("Level2 farm spawned.");
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

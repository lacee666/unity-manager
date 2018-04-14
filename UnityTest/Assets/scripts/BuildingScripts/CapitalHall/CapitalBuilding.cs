using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalBuilding : BuildingWorker {

    private float startTime;
    // Use this for initialization
    void Start()
    {
        cost = 10;
        startTime = Time.time;
        generateGoldPerSecond = 0;
        Debug.Log("CapitalHall farm spawned.");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
        if (elapsedTime >= secondsOfUpdate)
        {
            playerResources.Gold += generateGoldPerSecond;
            startTime = Time.time;
        }
        */
        SelectionUpdate();
    }

}

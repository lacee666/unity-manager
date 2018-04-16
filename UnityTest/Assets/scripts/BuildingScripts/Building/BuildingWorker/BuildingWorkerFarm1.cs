﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm1 : BuildingWorker {

    private float startTime;
	// Use this for initialization
	void Start () {
        level = 0;
        cost = 40;
        startTime = Time.time;
        generateGoldPerSecond = 1;

       // Debug.Log("Level1 farm spawned.");
    }
	
	// Update is called once per frame
	void Update () {
        float elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
        if(elapsedTime >= secondsOfUpdate)
        {
            playerResources.Gold += generateGoldPerSecond;
            startTime = Time.time;
        }
        //SelectionUpdate();
    }
    public override void Upgrade()
    {
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("farm_house_lvl2");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingWorkerFarm2>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

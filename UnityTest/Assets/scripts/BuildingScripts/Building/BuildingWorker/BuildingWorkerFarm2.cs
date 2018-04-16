using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm2 : BuildingWorker
{
    private float startTime;
    // Use this for initialization
    void Start()
    {
        level = 1;
        cost = 70;
        startTime = Time.time;
        generateGoldPerSecond = 2;
        secondsOfUpdate = 3.0f;
        //Debug.Log("Level2 farm spawned.");
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
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("farm_house_lvl3");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingWorkerFarm3>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

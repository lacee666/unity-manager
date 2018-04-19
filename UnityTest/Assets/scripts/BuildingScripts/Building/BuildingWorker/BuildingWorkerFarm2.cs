using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm2 : BuildingWorker
{
    private float startTime;

    private void Awake()
    {
        cost = 120;
    }
    void Start()
    {
        level = 1;
        startTime = Time.time;
        generateGoldPerSecond = 7;
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
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("farm_house_lvl3");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingWorkerFarm3>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

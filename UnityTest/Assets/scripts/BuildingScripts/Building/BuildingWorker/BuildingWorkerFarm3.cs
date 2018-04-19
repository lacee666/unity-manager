using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm3 : BuildingWorker
{
    private float startTime;
    private void Awake()
    {
        cost = 150;
    }
    void Start()
    {
        level = 2;
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
        Building temp = bi.Find("farm_house_lvl4");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingWorkerFarm4>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

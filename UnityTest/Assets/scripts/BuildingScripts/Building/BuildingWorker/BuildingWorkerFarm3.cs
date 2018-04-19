using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorkerFarm3 : BuildingWorker
{
    private float startTime;
    // Use this for initialization
    void Start()
    {
        level = 2;
        cost = 100;
        startTime = Time.time;
        generateGoldPerSecond = 12;
        secondsOfUpdate = 3.0f;
        //Debug.Log("Level3 farm spawned.");
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
       // Debug.Log(elapsedTime);
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

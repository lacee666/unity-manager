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
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

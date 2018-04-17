using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill1 : BuildingLumbermill
{

    private float startTime;

    void Start()
    {
        level = 0;
        cost = 20;
        startTime = Time.time;
        generateWoodPerSecond = 1;
        secondsOfUpdate = 3.0f;

    }
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= secondsOfUpdate)
        {
            playerResources.Wood += generateWoodPerSecond;
            startTime = Time.time;
        }

    }
    public override void Upgrade()
    {
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("lumbermill_lvl2");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingLumbermill2>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
    
}

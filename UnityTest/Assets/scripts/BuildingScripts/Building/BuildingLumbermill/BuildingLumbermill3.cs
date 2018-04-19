using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill3 : BuildingLumbermill {

    private float startTime;

    void Start()
    {
        level = 2;
        cost = 70;
        startTime = Time.time;
        generateWoodPerSecond = 8;
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
        Building temp = bi.Find("lumbermill_lvl4");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingLumbermill4>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }

}

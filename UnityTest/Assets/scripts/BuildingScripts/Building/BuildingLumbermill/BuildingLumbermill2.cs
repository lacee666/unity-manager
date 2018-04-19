using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill2 : BuildingLumbermill {

    private float startTime;

    void Start()
    {
        level = 1;
        cost = 40;
        startTime = Time.time;
        generateWoodPerSecond = 6;
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
        Building temp = bi.Find("lumbermill_lvl3");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingLumbermill3>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }

}

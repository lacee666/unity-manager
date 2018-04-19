using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLumbermill3 : BuildingLumbermill {

    private float startTime;
    private void Awake()
    {
        cost = 100;
    }
    void Start()
    {
        level = 2;
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
        Building temp = bi.Find("lumbermill_lvl4");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingLumbermill4>();
        go.AddComponent<BoxCollider>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower3 : BuildingTower
{
    private float startTime;

    void Start()
    {
        cost = 20;
        startTime = Time.time;


    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime >= secondsOfUpdate)
        {

            startTime = Time.time;
        }

    }

    public override void Upgrade()
    {
        BuildingInformation bi = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        Building temp = bi.Find("tower_lvl4");
        GameObject go = Instantiate(temp.prefab, this.transform.position, Quaternion.identity) as GameObject;
        go.AddComponent<BuildingTower4>();
        Destroy(go.GetComponent<BuildingStats>());
        Destroy(this.gameObject);
    }
}

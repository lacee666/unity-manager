using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBarracks : BaseBuilding {

    private Building prefab;

    private void Awake()
    {
        cost = 50;
    }
    void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        upgradeCost = 60;
		prefab = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>().Find("soldier");
	}

    public override void OnDestruction()
    {

    }
    public override void OnCreation()
    {

    }
    public override void Upgrade()
    {
        Debug.Log("Spawning soldier");
        StartCoroutine("SpawnSoldier");
    }

    IEnumerator SpawnSoldier()
    {
        playerResources.Capacity += 1;
        yield return new WaitForSeconds(2);       
        Instantiate(prefab.prefab, this.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
    }
}

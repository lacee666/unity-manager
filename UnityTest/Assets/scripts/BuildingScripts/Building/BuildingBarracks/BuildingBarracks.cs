using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBarracks : BaseBuilding {

    private PlayerResources playerResources;
    private Building prefab;
	// Use this for initialization
	void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        cost = 50;
        upgradeCost = 60;
		prefab = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>().Find("soldier");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnDestruction()
    {

    }
    public override void OnCreation()
    {

    }
    public void Upgrade()
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

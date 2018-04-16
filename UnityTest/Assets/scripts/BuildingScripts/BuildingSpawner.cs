using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    PlayerResources playerResources;
    BuildingInformation buildingInformation;
    Building building;
    private bool currentlyBuilding = false;
    private GameObject holdBuilding;
    private string[] farmNames = { "farm_house_lvl1", "farm_house_lvl2", "farm_house_lvl3", "farm_house_lvl4" };
    private string[] towerNames = { "tower_lvl1", "tower_lvl2", "tower_lvl3", "tower_lvl4" };
    public LayerMask buildingMask = 8;
    private int buildingType = 0;
    // Use this for initialization
    void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        holdBuilding = null;
        buildingInformation = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        building = new Building();

    }
	
	// Update is called once per frame
	void Update () {
        
        if (!currentlyBuilding)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                building = buildingInformation.Find(farmNames[playerResources.farmLevel]);
                if (building != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    //excluding buildings so we hit the ground
                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        //Debug.Log("Before: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 1;
                            SpawnHolder(hit);
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                building = buildingInformation.Find(towerNames[playerResources.towerLevel]);
                if (building != null)
                {

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    //excluding buildings so we hit the ground
                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        //Debug.Log("Before: " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 2;
                            SpawnHolder(hit);
                        }
                    }
                }
            }
        }
        else
        {
            if(holdBuilding != null)
            {
                FollowMouse();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                {                                                   
                    if (hit.collider.gameObject.name.Equals("Ground") && holdBuilding.GetComponent<BuildingStats>().CanSpawn)
                    {
                        GameObject buildingTemp = Instantiate(building.prefab, hit.point, Quaternion.identity) as GameObject;
                       
                        if(buildingType == 1)
                        {
                            Spawn(buildingTemp);
                        }else if(buildingType == 2)
                        {
                            SpawnTower(buildingTemp);
                        }                                             
                     
                        Destroy(holdBuilding);
                        currentlyBuilding = false;
                    }                                     
                }                                         
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if(holdBuilding != null)
                {
                    Destroy(holdBuilding);
                }
                currentlyBuilding = false;
            }
        }		
	}

 
    //the building following the mouse
    void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 1000, ~(1 << buildingMask.value)))
        {
            if (hit.collider.gameObject.name.Equals("Ground"))
            {
                holdBuilding.transform.position = hit.point;
            }
        }
        
    }
    
    void Spawn(GameObject buildingTemp)
    {
        int cost = 0;
        cost = BuildingCosts.FarmCost(playerResources.farmLevel);
        
        switch (playerResources.farmLevel)
        {
            case 0:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm1>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingWorkerFarm1>().Cost;
                    break;
                }
            case 1:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm2>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingWorkerFarm2>().Cost;
                    break;
                }
            case 2:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm3>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingWorkerFarm3>().Cost;
                    break;
                }
            case 3:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm4>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingWorkerFarm4>().Cost;
                    break;
                }
            default: break;
        }
        
        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            Destroy(buildingTemp.GetComponent<BuildingStats>());
        }
        else
        {
            Destroy(buildingTemp);

        }
        
    }
    void SpawnTower(GameObject buildingTemp)
    {
        int cost = 0;
        cost = BuildingCosts.TowerCost(playerResources.towerLevel);
        
        switch (playerResources.towerLevel)
        {
            case 0:
                {
                    buildingTemp.AddComponent<BuildingTower1>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingTower1>().Cost;
                    break;
                }
            case 1:
                {
                    buildingTemp.AddComponent<BuildingTower2>().enabled = true;
                    // cost = buildingTemp.GetComponent<BuildingTower2>().Cost;
                    break;
                }
            case 2:
                {
                    buildingTemp.AddComponent<BuildingTower3>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingTower3>().Cost;
                    break;
                }
            case 3:
                {
                    buildingTemp.AddComponent<BuildingTower4>().enabled = true;
                   // cost = buildingTemp.GetComponent<BuildingTower4>().Cost;
                    break;
                }
            default: break;
        }
        
        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            buildingTemp.GetComponent<SphereCollider>().radius = 2.0f;
            Destroy(buildingTemp.GetComponent<BuildingStats>());
        }
        else
        {
            Destroy(buildingTemp);
        }
             
        
    }
    void SpawnHolder(RaycastHit hit)
    {
        holdBuilding = Instantiate(building.prefab, hit.point, Quaternion.identity) as GameObject;
        holdBuilding.GetComponent<Renderer>().material.color = Color.green;
        holdBuilding.GetComponent<BuildingStats>().CanSpawn = true;
        holdBuilding.AddComponent<BoxCollider>();
        holdBuilding.GetComponent<SphereCollider>().isTrigger = true;

        //holdBuilding.GetComponent<Renderer>().material.color = Color.red;
        currentlyBuilding = true;

        //Debug.Log("Building found");
    }
}

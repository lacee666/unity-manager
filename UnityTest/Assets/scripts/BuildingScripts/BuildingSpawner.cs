using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    PlayerResources playerResources;
    BuildingInformation buildingInformation;
    Building building;
    //tempopary holder for building
    private GameObject holdBuilding;
    private bool currentlyBuilding = false;
    
    private string[] farmNames = { "farm_house_lvl1", "farm_house_lvl2", "farm_house_lvl3", "farm_house_lvl4" };
    private string[] towerNames = { "tower_lvl1", "tower_lvl2", "tower_lvl3", "tower_lvl4" };
    private string[] lumbermillNames = { "lumbermill_lvl1", "lumbermill_lvl2", "lumbermill_lvl3", "lumbermill_lvl4" };
    public LayerMask buildingMask = 8;

    //this decides what type of building we are spawning: 1-farm, 2-tower, 3-lumbermill, 4-barracks
    private int buildingType = 0;
    void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        buildingInformation = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>();
        holdBuilding = null;       
        building = new Building();

    }
	

	void Update () {
        if(Time.timeScale == 0)
        {
            return;
        }
        // if not currentlyBuilding then we can place the holdBuilding, type 1..4
        if (!currentlyBuilding)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                building = buildingInformation.Find(farmNames[playerResources.farmLevel]);
                if (building != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    //excluding buildings so we definitely hit the ground
                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 1;
                            //holdBuilding usage
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

                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 2;
                            SpawnHolder(hit);
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                building = buildingInformation.Find(lumbermillNames[playerResources.lumbermillLevel]);
                if (building != null)
                {

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 3;
                            SpawnHolder(hit);
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                building = buildingInformation.Find("barracks");
                if (building != null)
                {

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        if (hit.collider.gameObject.name.Equals("Ground"))
                        {
                            buildingType = 4;
                            SpawnHolder(hit);
                        }
                    }
                }
            }
        }
        //else we can place the building down if ground is accessible
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
                        }else if(buildingType == 3)
                        {
                            SpawnLumbermill(buildingTemp);
                        }
                        else if(buildingType == 4)
                        {
                            SpawnBarracks(buildingTemp);
                        }
                        
                        Destroy(holdBuilding);
                        currentlyBuilding = false;
                    }                                     
                }                                         
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (holdBuilding != null)
            {
                Destroy(holdBuilding);
            }
            currentlyBuilding = false;
        }
    }

 
    //the building following the mouse on the Ground
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
    //farm spawn
    void Spawn(GameObject buildingTemp)
    {
        int cost = -1;
        switch (playerResources.farmLevel)
        {
            case 0:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm1>().enabled = true;
                    break;
                }
            case 1:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm2>().enabled = true;
                    break;
                }
            case 2:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm3>().enabled = true;
                    break;
                }
            case 3:
                {
                    buildingTemp.AddComponent<BuildingWorkerFarm4>().enabled = true;
                    break;
                }
            default: break;
        }
        cost = buildingTemp.GetComponent<BaseBuilding>().Cost;

        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            buildingTemp.GetComponent<BaseBuilding>().OnCreation();
            Destroy(buildingTemp.GetComponent<BuildingStats>());
        }
        else
        {
            Destroy(buildingTemp);

        }
        
    }
    void SpawnBarracks(GameObject buildingTemp)
    {
        
        buildingTemp.AddComponent<BuildingBarracks>().enabled = true;
        int cost = buildingTemp.GetComponent<BaseBuilding>().Cost;
        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            buildingTemp.GetComponent<BaseBuilding>().OnCreation();
            Destroy(buildingTemp.GetComponent<BuildingStats>());
        }
        else
        {
            Destroy(buildingTemp);
        }
    }
    void SpawnLumbermill(GameObject buildingTemp)
    {
        switch (playerResources.lumbermillLevel)
        {
            case 0:
                {
                    buildingTemp.AddComponent<BuildingLumbermill1>().enabled = true;                
                    break;
                }
            case 1:
                {
                    buildingTemp.AddComponent<BuildingLumbermill2>().enabled = true;               
                    break;
                }
            case 2:
                {
                    buildingTemp.AddComponent<BuildingLumbermill3>().enabled = true;                
                    break;
                }
            case 3:
                {
                    buildingTemp.AddComponent<BuildingLumbermill4>().enabled = true;
                    break;
                }
            default: break;
        }
        int cost = buildingTemp.GetComponent<BaseBuilding>().Cost;
        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            buildingTemp.GetComponent<BaseBuilding>().OnCreation();
            Destroy(buildingTemp.GetComponent<BuildingStats>());
            
        }
        else
        {
            Destroy(buildingTemp);
        }
    }
    void SpawnTower(GameObject buildingTemp)
    {

        
        switch (playerResources.towerLevel)
        {
            case 0:
                {
                    buildingTemp.AddComponent<BuildingTower1>().enabled = true;
                    break;
                }
            case 1:
                {
                    buildingTemp.AddComponent<BuildingTower2>().enabled = true;
                    break;
                }
            case 2:
                {
                    buildingTemp.AddComponent<BuildingTower3>().enabled = true;
                    break;
                }
            case 3:
                {
                    buildingTemp.AddComponent<BuildingTower4>().enabled = true;
                    break;
                }
            default: break;
        }
        int cost = buildingTemp.GetComponent<BaseBuilding>().Cost;
        if (playerResources.Gold >= cost)
        {
            playerResources.Gold -= cost;
            buildingTemp.AddComponent<BoxCollider>().enabled = true;
            buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
            buildingTemp.GetComponent<SphereCollider>().radius = 2.0f;
            buildingTemp.GetComponent<BaseBuilding>().OnCreation();
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

        currentlyBuilding = true;
    }
}

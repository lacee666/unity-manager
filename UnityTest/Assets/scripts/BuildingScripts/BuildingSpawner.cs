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
    private int level = 0;
    public LayerMask buildingMask = 8;
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
                building = buildingInformation.Find(farmNames[level]);
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
                            holdBuilding = Instantiate(building.prefab, hit.point, Quaternion.identity) as GameObject;
                            holdBuilding.GetComponent<Renderer>().material.color = Color.green;
                            holdBuilding.GetComponent<BuildingStats>().CanSpawn = true;
                            holdBuilding.GetComponent<SphereCollider>().isTrigger = true;
                           
                            //holdBuilding.GetComponent<Renderer>().material.color = Color.red;
                            currentlyBuilding = true;
                            Debug.Log("Building found");

                        }
                    }
                }
            }
        }
        else
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                {
                    //Debug.Log(holdBuilding.GetComponent<BuildingStats>().CanSpawn);
                    //Debug.Log(hit.collider.gameObject.name);
                    int cost = FarmCost(level);
                    Debug.Log("Cost is: " + cost);
                    if (hit.collider.gameObject.name.Equals("Ground") && holdBuilding.GetComponent<BuildingStats>().CanSpawn && playerResources.Gold >= cost)
                    {
                        GameObject buildingTemp = Instantiate(building.prefab, hit.point, Quaternion.identity) as GameObject;
                        playerResources.Gold -= cost;
                        Spawn(buildingTemp);
                        
                     
                        Destroy(holdBuilding);
                        //Debug.Log("Before level increased.");
                       /* if (level < 3)
                        {
                            //Debug.Log("Level increased.");
                            level++;
                        }*/
                        currentlyBuilding = false;
                        //Debug.Log("Building spawned.");
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
                //Debug.Log("Cancelled building.");
            }
        }
      //  Debug.Log(level);
		
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
    int FarmCost(int level)
    {
        switch (level)
        {
            case 0:
                {
                    return BuildingWorkerFarm1.cost;
                }
            case 1:
                {
                    return BuildingWorkerFarm2.cost;
                }
            case 2:
                {

                    return BuildingWorkerFarm3.cost;
                }
            case 3:
                {
                    return BuildingWorkerFarm4.cost;
                }
            default: return 10000;
        }
    }
    void Spawn(GameObject buildingTemp)
    {
        
        switch (level)
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
        buildingTemp.AddComponent<BoxCollider>().enabled = true;
        buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
        Destroy(buildingTemp.GetComponent<BuildingStats>());
    }
}

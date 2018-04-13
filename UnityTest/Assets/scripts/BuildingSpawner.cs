using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    BuildingInformation buildingInformation;
    Building building;
    private bool currentlyBuilding = false;
    private GameObject holdBuilding;
    private string[] farmNames = { "farm_house_lvl1", "farm_house_lvl2", "farm_house_lvl3", "farm_house_lvl4" };
    private int level = 0;
    public LayerMask buildingMask = 8;
    // Use this for initialization
    void Start () {
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
                    if (Physics.Raycast(ray, out hit, 1000.0f, ~(1 << buildingMask.value)))
                    {
                        Debug.Log("Before: " + hit.collider.gameObject.name);
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
                    Debug.Log(holdBuilding.GetComponent<BuildingStats>().CanSpawn);
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name.Equals("Ground") && holdBuilding.GetComponent<BuildingStats>().CanSpawn)
                    {
                        GameObject buildingTemp = Instantiate(building.prefab, hit.point, Quaternion.identity) as GameObject;
                        buildingTemp.AddComponent<BoxCollider>().enabled = true;
                        buildingTemp.GetComponent<SphereCollider>().isTrigger = true;
                        Destroy(buildingTemp.GetComponent<BuildingStats>());
                        Destroy(holdBuilding);
                        Debug.Log("Before level increased.");
                        if (level < 3)
                        {
                            Debug.Log("Level increased.");
                            level++;
                        }
                        currentlyBuilding = false;
                        Debug.Log("Building spawned.");
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
                Debug.Log("Cancelled building.");
            }
        }
      //  Debug.Log(level);
		
	}

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
}

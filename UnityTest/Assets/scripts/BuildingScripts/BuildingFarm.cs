using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFarm : MonoBehaviour {

    private int level = 1;
	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            /*
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
            }*/
        }
    }
}

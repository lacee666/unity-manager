using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class BuildingSelection : MonoBehaviour {

    public LayerMask buildingMask = 8;
    // this will be the selected building
    private GameObject focus;

    // not in use
    private GameObject uiHolder;

    private GameObject buildingInformationUI;
    private PlayerResources playerResources;

    void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        // buildingInformationUI = Resources.Load("buildingInformationUI", typeof(GameObject)) as GameObject;
        buildingInformationUI = GameObject.Find("buildingInformationUI");
        buildingInformationUI.SetActive(false);       
    }
	
	void LateUpdate () {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            //Debug.Log("Mouse click happened at: " + ray);
            if (Physics.Raycast(ray, out hit, 1500.0f, (1 << buildingMask.value)))
            {
                //Debug.Log("Mouse click on building: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag.Equals("Building"))
                {
                   //Debug.Log("Mouse click on building and tag: ");
                    Debug.Log("OBJ name: " + hit.collider.gameObject);
                   /* if(focus != hit.collider.gameObject)
                    {
                         Debug.Log("NEW OBJ name: " + hit.collider.gameObject);
                         DeleteUI();
                    }*/
                    focus = hit.collider.gameObject;

                    int cost = focus.GetComponent<BaseBuilding>().Cost;
                    focus.GetComponent<BaseBuilding>().Selected = true;
                    focus.GetComponent<BaseBuilding>().SelectionUpdate();
                    PopupUI();
                   
                   
                    GameObject.Find("upgrade_text").GetComponent<TextMeshProUGUI>().SetText("Upgrade: " + cost);
                    //Debug.Log(focus.gameObject.name);
                    
                }
            }
            else
            {

                if (focus != null)
                {
                    focus.GetComponent<BaseBuilding>().Selected = false;
                    focus.GetComponent<BaseBuilding>().SelectionUpdate();
                }

            }
        
        }
        
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            if (focus != null)
            {
                
                focus.GetComponent<BaseBuilding>().Selected = false;
                focus.GetComponent<BaseBuilding>().SelectionUpdate();
                /*
                if (focus.GetComponent<BaseBuilding>() is BuildingWorker)
                {
  
                    focus.GetComponent<BuildingWorker>().Selected = false;
                    focus.GetComponent<BuildingWorker>().SelectionUpdate();
                    
                }
                else if (focus.GetComponent<BaseBuilding>() is BuildingTower)
                {
                    
                    focus.GetComponent<BuildingTower>().Selected = false;
                    focus.GetComponent<BuildingTower>().SelectionUpdate();                 
                }
                else if (focus.GetComponent<BaseBuilding>() is BuildingLumbermill)
                {

                    focus.GetComponent<BuildingLumbermill>().Selected = false;
                    focus.GetComponent<BuildingLumbermill>().SelectionUpdate();
                }
                */

                DeleteUI();
            }
        }
        if(focus != null && buildingInformationUI != null)
        {
            buildingInformationUI.transform.position = Camera.main.WorldToScreenPoint(focus.transform.position);
        }
    }
    public void PopupUI()
    {
        Debug.Log("UI popped up.");
        buildingInformationUI.transform.position = Camera.main.WorldToScreenPoint(focus.transform.position);
        buildingInformationUI.SetActive(true);
        GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.white;
        /*
        Debug.Log("Cost: " + playerResources.Gold + " < " + focus.GetComponent<BaseBuilding>().Cost);
        if (playerResources.Gold < focus.GetComponent<BaseBuilding>().Cost || playerResources.farmLevel < focus.GetComponent<BaseBuilding>().Level)
        {
            GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        */
        if (focus.GetComponent<BaseBuilding>() is BuildingWorker)
        {
            //Debug.Log("Text red in farm");
            BuildingWorker bw = focus.GetComponent<BuildingWorker>();
            if (playerResources.Gold < bw.Cost || playerResources.farmLevel <= bw.Level)
            {
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }
        else if (focus.GetComponent<BaseBuilding>() is BuildingTower)
        {
            //Debug.Log("Text red in tower");
            BuildingTower bw = focus.GetComponent<BuildingTower>();
            if (playerResources.Gold < bw.Cost || playerResources.towerLevel <= bw.Level)
            {
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }
        else if (focus.GetComponent<BaseBuilding>() is BuildingLumbermill)
        {
            BuildingLumbermill bw = focus.GetComponent<BuildingLumbermill>();
            if (playerResources.Gold < bw.Cost || playerResources.lumbermillLevel <= bw.Level)
            {
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }

        //uiHolder = Instantiate(buildingInformationUI);
        //uiHolder.transform.parent = (GameObject.Find("Canvas").transform);
        //GameObject.Find("buildingInformationUI/upgrade").GetComponent<Button>().onClick.AddListener(() => OnUpgrade());
        //GameObject.Find("buildingInformationUI/destroy").GetComponent<Button>().onClick.AddListener(() => OnDestroy());
        //buildingInformationUI.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { OnUpgrade(); });
        //buildingInformationUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate{ OnDestroy(); });
    }
    public void DeleteUI()
    {
        Debug.Log("UI Deleted.");
        if (buildingInformationUI != null)
        {
            buildingInformationUI.SetActive(false);
        }      
    }

    public void OnUpgrade()
    {
        
        Debug.Log("Upgrading...");
        if(focus != null)
        {
            if(focus.GetComponent<BaseBuilding>() is BuildingWorker)
            {
                Debug.Log("Upgrading BW...");
                if (playerResources.Gold >= BuildingCosts.FarmUpgradeCost() && playerResources.farmLevel > focus.GetComponent<BuildingWorker>().Level)
                {
                    playerResources.Gold -= BuildingCosts.FarmUpgradeCost();
                    focus.GetComponent<BuildingWorker>().Upgrade();
                    DeleteUI();
                }
            } else if(focus.GetComponent<BaseBuilding>() is BuildingTower)
            {
                Debug.Log("Upgrading BT...");
                Debug.Log(playerResources.towerLevel);
                Debug.Log(focus.GetComponent<BuildingTower>().Level);
                if (playerResources.Gold >= BuildingCosts.TowerUpgradeCost() && playerResources.towerLevel > focus.GetComponent<BuildingTower>().Level)
                {
                    playerResources.Gold -= BuildingCosts.TowerUpgradeCost();
                    focus.GetComponent<BuildingTower>().Upgrade();
                    DeleteUI();
                }
            }
            else if (focus.GetComponent<BaseBuilding>() is BuildingLumbermill)
            {
                Debug.Log("Upgrading BL...");
                Debug.Log(playerResources.lumbermillLevel);
                Debug.Log(focus.GetComponent<BuildingLumbermill>().Level);
                if (playerResources.Gold >= BuildingCosts.LumbermillUpgradeCost() && playerResources.lumbermillLevel > focus.GetComponent<BuildingLumbermill>().Level)
                {
                    playerResources.Gold -= BuildingCosts.LumbermillUpgradeCost();
                    focus.GetComponent<BuildingLumbermill>().Upgrade();
                    DeleteUI();
                }
            }
        }
                  
    }

    public void OnDestroy()
    {
        playerResources.Gold += 10;
        if(focus != null)
        {
            focus.GetComponent<BaseBuilding>().OnDestruction();
            Destroy(focus);
        }
        
        DeleteUI();
    }
}

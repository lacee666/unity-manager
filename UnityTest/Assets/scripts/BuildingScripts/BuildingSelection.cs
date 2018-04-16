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
    //
    private GameObject uiHolder;
    private GameObject buildingInformationUI;
    private PlayerResources playerResources;
    // Use this for initialization
    void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        buildingInformationUI = GameObject.Find("buildingInformationUI");
        buildingInformationUI.SetActive(false);

        //
        //buildingInformationUI = Resources.Load("buildingInformationUI", typeof(GameObject)) as GameObject;
    }
	
	void LateUpdate () {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            //Debug.Log("Mouse click on: ");
            if (Physics.Raycast(ray, out hit, 1000.0f, (1 << buildingMask.value)))
            {
               // Debug.Log("Mouse click on building: ");
                if (hit.collider.gameObject.tag.Equals("Building"))
                {
                    //Debug.Log("Mouse click on building and tag: ");
                    focus = hit.collider.gameObject;
                    int cost = 0;
                    if (focus.GetComponent<BaseBuilding>() is BuildingWorker)
                    {
                        cost = BuildingCosts.FarmUpgradeCost();
                        focus.GetComponent<BuildingWorker>().Selected = true;
                        focus.GetComponent<BuildingWorker>().SelectionUpdate();
                    }
                    else if (focus.GetComponent<BaseBuilding>() is BuildingTower)
                    {
                        cost = BuildingCosts.TowerUpgradeCost();
                        focus.GetComponent<BuildingTower>().Selected = true;
                        focus.GetComponent<BuildingTower>().SelectionUpdate();
                    }
                   
                    PopupUI();
                   
                   
                    GameObject.Find("upgrade_text").GetComponent<TextMeshProUGUI>().SetText("Upgrade: " + cost);
                    //Debug.Log(focus.gameObject.name);
                    
                }
            }
            else
            {

                if (focus != null)
                {
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

                }

            }
        
        }
        
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            if (focus != null)
            {
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
            Debug.Log("Text red in farm");
            BuildingWorker bw = focus.GetComponent<BuildingWorker>();
            if (playerResources.Gold < bw.Cost || playerResources.farmLevel <= bw.Level)
            {
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }
        else if (focus.GetComponent<BaseBuilding>() is BuildingTower)
        {
            Debug.Log("Text red in tower");
            BuildingTower bw = focus.GetComponent<BuildingTower>();
            if (playerResources.Gold < bw.Cost || playerResources.towerLevel <= bw.Level)
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
        }
       
        
    }

    public void OnDestroy()
    {
        playerResources.Gold += 10;
        Destroy(focus);
        DeleteUI();
    }
}

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
    private GameObject buildingInformationUI;
    private PlayerResources playerResources;

    // not in use
    private GameObject uiHolder;

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
            if (Physics.Raycast(ray, out hit, 1500.0f, (1 << buildingMask.value)))
            {
                if (hit.collider.gameObject.tag.Equals("Building"))
                {             
                    focus = hit.collider.gameObject;
                    int cost = focus.GetComponent<BaseBuilding>().Cost;
                    focus.GetComponent<BaseBuilding>().Selected = true;
                    focus.GetComponent<BaseBuilding>().SelectionUpdate();
                    PopupUI();                 
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
        //places the UI on top of the selected building
        buildingInformationUI.transform.position = Camera.main.WorldToScreenPoint(focus.transform.position);
        buildingInformationUI.SetActive(true);
        TextMeshProUGUI text = GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>();
        text.color = Color.white;

        //cost handling
        if (focus.GetComponent<BaseBuilding>() is BuildingBarracks)
        {
                     
            BuildingBarracks bw = focus.GetComponent<BuildingBarracks>();
            text.SetText("Buy soldier: " + bw.Cost);
            if (playerResources.Wood < bw.Cost)
            {
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }
        else
        {           
            text.SetText("Upgrade" + focus.GetComponent<BaseBuilding>().Cost);
            /*
            BaseBuilding bws = focus.GetComponent<BaseBuilding>();
            if (playerResources.Gold < bws.Cost || playerResources.lumbermillLevel <= bws.Level)
            {
                Debug.Log("Not enough: " + playerResources.Gold + "<" + bws.Cost + "||" + playerResources.lumbermillLevel + "<=" + bws.Level);
                GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            */
            if (focus.GetComponent<BaseBuilding>() is BuildingWorker)
            {
                BuildingWorker bw = focus.GetComponent<BuildingWorker>();
                if (playerResources.Gold < bw.Cost || playerResources.farmLevel <= bw.Level)
                {
                    GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
                }
            }
            else if (focus.GetComponent<BaseBuilding>() is BuildingTower)
            {
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
           
        }
        /*
        Debug.Log("Cost: " + playerResources.Gold + " < " + focus.GetComponent<BaseBuilding>().Cost);
        if (playerResources.Gold < focus.GetComponent<BaseBuilding>().Cost || playerResources.farmLevel < focus.GetComponent<BaseBuilding>().Level)
        {
            GameObject.Find("upgrade/upgrade_text").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        */

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
        if(focus != null)
        {
            /*
            if (playerResources.Gold >= focus.GetComponent<BaseBuilding>().UpgradeCost && playerResources.farmLevel > focus.GetComponent<BaseBuilding>().Level)
            {
                playerResources.Gold -= focus.GetComponent<BaseBuilding>().UpgradeCost;
                focus.GetComponent<BaseBuilding>().Upgrade();
                DeleteUI();
            }
            */          
            if (focus.GetComponent<BaseBuilding>() is BuildingWorker)
            {
                if (playerResources.Gold >= focus.GetComponent<BuildingWorker>().UpgradeCost && playerResources.farmLevel > focus.GetComponent<BuildingWorker>().Level)
                {
                    playerResources.Gold -= focus.GetComponent<BuildingWorker>().UpgradeCost;
                    focus.GetComponent<BuildingWorker>().Upgrade();
                    DeleteUI();
                }
            } else if(focus.GetComponent<BaseBuilding>() is BuildingTower)
            {
                if (playerResources.Gold >= focus.GetComponent<BuildingTower>().UpgradeCost && playerResources.towerLevel > focus.GetComponent<BuildingTower>().Level)
                {
                    playerResources.Gold -= focus.GetComponent<BuildingTower>().UpgradeCost;
                    focus.GetComponent<BuildingTower>().Upgrade();
                    DeleteUI();
                }
            }
            else if (focus.GetComponent<BaseBuilding>() is BuildingLumbermill)
            {
                Debug.Log(playerResources.lumbermillLevel + ">" + focus.GetComponent<BuildingLumbermill>().Level);
                if (playerResources.Gold >= focus.GetComponent<BuildingLumbermill>().UpgradeCost && playerResources.lumbermillLevel > focus.GetComponent<BuildingLumbermill>().Level)
                {
                    playerResources.Gold -= focus.GetComponent<BuildingLumbermill>().UpgradeCost;
                    focus.GetComponent<BuildingLumbermill>().Upgrade();
                    DeleteUI();
                }
            }
            else if (focus.GetComponent<BaseBuilding>() is BuildingBarracks)
            {

                if (playerResources.Wood >= focus.GetComponent<BuildingBarracks>().UpgradeCost && playerResources.Capacity < playerResources.MaxCapacity)
                {
                    playerResources.Wood -= focus.GetComponent<BuildingBarracks>().UpgradeCost;
                    focus.GetComponent<BuildingBarracks>().Upgrade();
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

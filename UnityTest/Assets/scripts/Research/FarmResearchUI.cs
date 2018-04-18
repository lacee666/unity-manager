using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class FarmResearchUI : MonoBehaviour, IPointerClickHandler
{
    PlayerResources playerResources;
    private int upgradeCost = 400;

    TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        
        
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        this.GetComponentInChildren<TextMeshProUGUI>().text = "Farm upgrade(" + (playerResources.towerLevel + 1) + "): " + upgradeCost + " gold";

        text = GameObject.Find("farm_upgrade_ui/cost").GetComponent<TextMeshProUGUI>();
        text.text = "Cost: " + BuildingCosts.FarmCost(playerResources.farmLevel).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Levels: " + playerResources.farmLevel + "<" + playerResources.maxFarmLevel);
        if (playerResources.Gold >= upgradeCost && playerResources.farmLevel < playerResources.maxFarmLevel)
        {
            Debug.Log("Farm upgraded.");
            playerResources.Gold -= upgradeCost;
            playerResources.farmLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Farm upgrade(" + (playerResources.farmLevel+1) + "): " + upgradeCost+ " gold";
            text.text = "Cost: " + BuildingCosts.FarmCost(playerResources.farmLevel).ToString();
        }
    }
}

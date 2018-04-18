using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class TowerResearchUI : MonoBehaviour, IPointerClickHandler
{
    PlayerResources playerResources;
    private int upgradeCost = 500;
    TextMeshProUGUI text;
    // Use this for initialization
    void Start()
    {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        this.GetComponentInChildren<TextMeshProUGUI>().text = "Tower upgrade(" + (playerResources.towerLevel + 1) + "): " + upgradeCost + " gold";

        text = GameObject.Find("tower_upgrade_ui/cost").GetComponent<TextMeshProUGUI>();
        text.text = "Cost: " + BuildingCosts.TowerCost(playerResources.lumbermillLevel).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (playerResources.Gold >= upgradeCost && playerResources.towerLevel < playerResources.maxTowerLevel)
        {
            Debug.Log("Tower upgraded.");
            playerResources.Gold -= upgradeCost;
            playerResources.towerLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Tower upgrade(" + (playerResources.towerLevel+1) + "): " + upgradeCost + " gold";
            text.text = "Cost: " + BuildingCosts.FarmCost(playerResources.lumbermillLevel).ToString();
        }
    }
}
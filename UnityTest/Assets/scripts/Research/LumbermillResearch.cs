using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class LumbermillResearch : MonoBehaviour, IPointerClickHandler
{
    PlayerResources playerResources;
    private int upgradeCost = 300;
    TextMeshProUGUI text;
    // Use this for initialization
    void Start()
    {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        this.GetComponentInChildren<TextMeshProUGUI>().text = "Lumbermill upgrade(" + (playerResources.towerLevel + 1) + "): " + upgradeCost + " gold";
        text = GameObject.Find("lumbermill_upgrade_ui/cost").GetComponent<TextMeshProUGUI>();
        text.text = "Cost: " + BuildingCosts.LumbermillCost(playerResources.lumbermillLevel).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (playerResources.Gold >= upgradeCost && playerResources.lumbermillLevel < playerResources.maxLumbermillLevel)
        {
            //Debug.Log("Farm upgraded.");
            playerResources.Gold -= upgradeCost;
            playerResources.lumbermillLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Lumbermill upgrade(" + (playerResources.lumbermillLevel + 1) + "): " + upgradeCost + " gold";
            text.text = "Cost: " + BuildingCosts.LumbermillCost(playerResources.lumbermillLevel).ToString();
        }
    }
}

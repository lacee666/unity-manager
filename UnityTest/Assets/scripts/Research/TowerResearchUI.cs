using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class TowerResearchUI : MonoBehaviour, IPointerClickHandler
{
    PlayerResources playerResources;
    // Use this for initialization
    void Start()
    {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (playerResources.Gold >= 100 && playerResources.towerLevel < playerResources.maxTowerLevel)
        {
            Debug.Log("Tower upgraded.");
            playerResources.Gold -= 100;
            playerResources.towerLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Tower(" + (playerResources.towerLevel+1) + "): 100 gold";
        }
    }
}
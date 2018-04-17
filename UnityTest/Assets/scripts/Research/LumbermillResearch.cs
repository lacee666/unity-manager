using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class LumbermillResearch : MonoBehaviour, IPointerClickHandler
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

        if (playerResources.Gold >= 100 && playerResources.lumbermillLevel < playerResources.maxLumbermillLevel)
        {
            Debug.Log("Farm upgraded.");
            playerResources.Gold -= 100;
            playerResources.lumbermillLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Lumbermill(" + (playerResources.lumbermillLevel + 1) + "): 100 gold";
        }
    }
}

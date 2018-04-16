using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class FarmResearchUI : MonoBehaviour, IPointerClickHandler
{
    PlayerResources playerResources;
	// Use this for initialization
	void Start () {
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Levels: " + playerResources.farmLevel + "<" + playerResources.maxFarmLevel);
        if (playerResources.Gold >= 100 && playerResources.farmLevel < playerResources.maxFarmLevel)
        {
            Debug.Log("Farm upgraded.");
            playerResources.Gold -= 100;
            playerResources.farmLevel += 1;
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Farm(" + (playerResources.farmLevel+1) + ")";
        }
    }
}

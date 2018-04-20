using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class XpUI : MonoBehaviour {

    PlayerResources playerResources;
    Image xpImage;
    //TextMeshProUGUI levelUI;
    int i = 1;

    void Start () {
        //levelUI = GameObject.Find("XPText").GetComponent<TextMeshProUGUI>();
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        xpImage = GameObject.Find("CurrentXp").GetComponent<Image>();
    }
	
	void LateUpdate () {
        xpImage.fillAmount = ((playerResources.Xp * 1.0f) / (MaxXp(i) *1.0f));
        //Debug.Log("Fill: " + xpImage.fillAmount + "and xp is " + playerResources.Xp + "and max is " + MaxXp(i));
        if(xpImage.fillAmount >= 1)
        {
            i++;
            playerResources.Xp = 0;
            playerResources.PlayerLevel++;
            this.GetComponent<Text>().text = playerResources.PlayerLevel.ToString() + "level, xp "  + playerResources.Xp;
        }


        else
        {
            this.GetComponent<Text>().text = "Level:" + playerResources.PlayerLevel.ToString() + ", xp " + playerResources.Xp.ToString() + "/" + MaxXp(i);
        }
	}

    int MaxXp(int i)
    {
        return 50 * i;
    }
}

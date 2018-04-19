using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpperBarGui : MonoBehaviour {

    private Text goldText;
    private Text steelText;
    private Text capacityText;

	void Start () {
        goldText = GameObject.Find("gold_bar/gold_text").GetComponent<Text>();
        steelText = GameObject.Find("steel_bar/steel_text").GetComponent<Text>();
        capacityText = GameObject.Find("capacity_bar/capacity_text").GetComponent<Text>();
    }
	
    public void UpdateUpperBarGui(int goldValue, int steelValue, int capacityValue, int maxCapacityValue)
    {
        goldText.text = goldValue.ToString();
        steelText.text = steelValue.ToString();
        capacityText.text = capacityValue.ToString() + "/" + maxCapacityValue.ToString();
    }
}

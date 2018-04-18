using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveUI : MonoBehaviour {

    TextMeshProUGUI text;
    AIWaveHandler aiWaveHandler;
	// Use this for initialization
	void Start () {
        aiWaveHandler = GameObject.Find("AIHolder").GetComponent<AIWaveHandler>();
        text = this.GetComponent<TextMeshProUGUI>();
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DeleteText()
    {
       
        yield return new WaitForSeconds(5);
        text.text = "";

    }
    public void NotifyWaveUI(int number)
    {
        switch (number)
        {
            case 0:
                {
                    text.text = "Wave coming from west";                 
                    break;
                }
            case 1:
                {
                    text.text = "Wave coming from east";
                    break;
                }
            case 2:
                {
                    text.text = "Wave coming from south";
                    break;
                }
        }
        StartCoroutine("DeleteText");
    }
}

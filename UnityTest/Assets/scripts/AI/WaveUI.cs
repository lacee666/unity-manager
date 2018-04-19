using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveUI : MonoBehaviour {

    TextMeshProUGUI text;
    AIWaveHandler aiWaveHandler;
    string[] waveText = new string[3]{ "Wave coming from west", "Wave coming from east", "Wave coming from south" };

	void Start () {
        aiWaveHandler = GameObject.Find("AIHolder").GetComponent<AIWaveHandler>();
        text = this.GetComponent<TextMeshProUGUI>();
        this.enabled = false;
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
                    text.text = waveText[0];                 
                    break;
                }
            case 1:
                {
                    text.text = waveText[1];
                    break;
                }
            case 2:
                {
                    text.text = waveText[2];
                    break;
                }
        }
        StartCoroutine("DeleteText");
    }
}

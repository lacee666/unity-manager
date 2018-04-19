using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveTimeText : MonoBehaviour {

    AIWaveHandler aiWaveHandler;
    TextMeshProUGUI text;
    
    void Start()
    {
        aiWaveHandler = GameObject.Find("AIHolder").GetComponent<AIWaveHandler>();
        text = this.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        text.text = (aiWaveHandler.i-1) + ". wave in: " + aiWaveHandler.WaveTime.ToString("F0");
    }
}

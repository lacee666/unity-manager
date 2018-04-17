using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveTimeText : MonoBehaviour {


    TextMeshProUGUI text;
    AIWaveHandler aiWaveHandler;
    // Use this for initialization
    void Start()
    {
        aiWaveHandler = GameObject.Find("AIHolder").GetComponent<AIWaveHandler>();
        text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Next wave in: " + aiWaveHandler.WaveTime.ToString("F2");
    }
}

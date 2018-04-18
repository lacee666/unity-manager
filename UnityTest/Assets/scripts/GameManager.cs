using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour {

    private GameObject health;
    private AIWaveHandler aiWaveHandler;
    private TextMeshProUGUI text;
    private GameObject endUI;
    void Start () {
        Time.timeScale = 1.0f;
        endUI = GameObject.Find("EndUI");
        text = GameObject.Find("Win_text").GetComponent<TextMeshProUGUI>();
        aiWaveHandler = GameObject.Find("AIHolder").GetComponent<AIWaveHandler>();
        health = GameObject.Find("Capital_Hall");
        endUI.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		if(health == null)
        {
            Debug.Log("LOST");
            LoseUI();
        }
        if(aiWaveHandler.i >= 12)
        {
            WinUI();
        }
	}

    public void LoseUI()
    {
        endUI.SetActive(true);
        Time.timeScale = 0;
        text.text = "You lost!";
    }
    public void WinUI()
    {
        endUI.SetActive(true);
        Time.timeScale = 0;
        
        text.text = "You won!";
    }
}

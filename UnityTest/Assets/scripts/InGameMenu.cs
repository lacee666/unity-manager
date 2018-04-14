using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

    private GameObject menu;
    private bool menuOn;
    public void Start()
    {
        menuOn = false;
        menu = GameObject.Find("menu");
        menu.SetActive(false);
    }
    public void Cancel()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOn)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Escape) && menuOn)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
    public void BackToMenu()
    {
        Application.LoadLevel("menu");
    }
}

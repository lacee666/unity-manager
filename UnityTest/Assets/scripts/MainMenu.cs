using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {


    public void Start()
    {
 
    }
    public void Play()
    {
        SceneManager.LoadScene("test");
    }

    public void Exit() {
        Application.Quit();
    }
    /*
    public void KeyBoard()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void BackToMenu()
    {
        main.SetActive(true);
        options.SetActive(false);
    }
    */
}

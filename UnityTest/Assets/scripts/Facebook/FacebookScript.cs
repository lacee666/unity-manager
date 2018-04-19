using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using TMPro;
public class FacebookScript : MonoBehaviour {


    public TextMeshProUGUI userIdText;
    public Image image;
 
    public void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() => {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    Debug.Log("Error initializing facebook.");
                }
            }, isGameShown => {
                if (!isGameShown)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            });
        }
        else
        {
            FB.ActivateApp();
        }
        

    }


    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email" };

        FB.LogInWithReadPermissions(permissions, AuthCallBack);
        //

    }
    void AuthCallBack(IResult result)
    {
        if(result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("LOGGED IN");

                //Application.LoadLevel("test");

            }
            else
            {
                Debug.Log("NOT LOGGED IN");
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
    }
    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUserName);
        }
        else
        {

        }
    }
    void DisplayUserName(IResult result)
    {
        //GameObject.Find("facebook_name").GetComponent<TextMeshProUGUI>().text = "Hi, " + result.ResultDictionary["first_name"].ToString();
        //GameObject.Find("facebook_bar").GetComponent<Image>().sprite = result.ResultDictionary["cover"] as Sprite;
    }
    public void FacebookLogout()
    {
        FB.LogOut();
    }

    public void Share()
    {
        FB.ShareLink(
            contentTitle: "LUL",
            contentURL: new System.Uri("https://google.hu"),
            contentDescription: "VI VON",
            callback: OnShare

        );
    }

    void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share error");
        }else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log("Share error post");
        }
        else
        {
            Debug.Log("Share ok");
        }
    }
}

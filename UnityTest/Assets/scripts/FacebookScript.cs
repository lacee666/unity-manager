using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
public class FacebookScript : MonoBehaviour {

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

    #region login
    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);

    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }
    /*
    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("http://resocoder.com"), "LuL", "LuLL");
    }
    */
    #endregion
}

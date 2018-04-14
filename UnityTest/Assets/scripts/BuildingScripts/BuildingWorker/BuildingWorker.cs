using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorker : MonoBehaviour {
    protected static PlayerResources playerResources;
    protected int generateGoldPerSecond;
    protected float secondsOfUpdate = 3.0f;
    public static int cost;
    public int Cost
    {
        get { return cost; }
    }
    private void Awake()
    {
     
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {

    private int gold = 700;
    private int wood = 200;
    private int capacity = 0;
    private int maxCapacity = 1;
    public int farmLevel = 0;
    public int maxFarmLevel = 3;

    public int towerLevel = 0;
    public int maxTowerLevel = 3;

    public int barracksLevel = 0;
    public int maxBarracksLevel = 3;

    public int lumbermillLevel = 0;
    public int maxLumbermillLevel = 3;

    public int Gold
    {
        get { return gold; }
        set { if (value >= 0) {
                gold = value;
            }
            else
            {
                gold = 0;
            }
        }
    }
   
    public int Wood
    {
        get { return wood; }
        set
        {
            if (value >= 0)
            {
                wood = value;
            }
            else
            {
                wood = 0;
            }
        }
    }
   
    public int Capacity
    {
        get { return capacity; }
        set
        {
            if (value >= 0)
            {
                capacity = value;
            }
            else
            {
                capacity = 0;
            }
        }
    }
    
    public int MaxCapacity
    {
        get { return maxCapacity; }
        set
        {
            if (value >= 0)
            {
                maxCapacity = value;
            }
            else
            {
                maxCapacity = 0;
            }
        }
    }


    private UpperBarGui upperBarGui;
	// Use this for initialization
	void Start () {
        upperBarGui = GameObject.Find("UpperBarGuiHolder").GetComponent<UpperBarGui>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        upperBarGui.UpdateUpperBarGui(gold, wood, capacity, maxCapacity);
    }
    
    public void PlayMusic()
    {
        this.GetComponent<AudioSource>().Play();
    }

    public void StopMusic()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}

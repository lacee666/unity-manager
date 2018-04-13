using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInformation : MonoBehaviour {

    [SerializeField]
    public Building[] buildings;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Building Find(string name)
    {
        for(int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i].name.Equals(name))
            {
                return buildings[i];
            }
        }
        return null;
    }
}

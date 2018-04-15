using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInformation : MonoBehaviour {

    [SerializeField]
    public Building[] buildings;


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

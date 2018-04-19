using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class describes a building... and other objects too...
[System.Serializable]
public class Building{
    public string name;
    public int cost;
    public Object prefab;
    protected int level = 0;
    public int Level
    {
        get { return level; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour {

   
    protected static PlayerResources playerResources;
    protected Renderer renderer;
    protected Material material;
    public static string selectionOutlineShaderName = "TSF/BaseOutline1";
    protected float secondsOfUpdate;
    protected int level = 0;

    protected int upgradeCost;
    public int UpgradeCost
    {
        get { return upgradeCost; }
    }

    public int Level
    {
        get { return level; }
    }

    public int cost = 0;
    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }
    protected bool selected = false;
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }
    private void Awake()
    {
        renderer = this.GetComponent<Renderer>();
        material = new Material(renderer.material);
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
    }
    public void SelectionUpdate()
    {
        if (selected)
        {
            OnSelection();
        }
        else
        {
            //Deselect();
        }
    }

    public void OnSelection()
    {
        //renderer.material.shader = Shader.Find(selectionOutlineShaderName);
    }
    public void Deselect()
    {
        renderer.material = material;
    }
    public virtual void OnDestruction()
    {

    }
    public virtual void OnCreation()
    {

    }
    public virtual void Upgrade()
    {

    }
    protected int generateGoldPerSecond;
}

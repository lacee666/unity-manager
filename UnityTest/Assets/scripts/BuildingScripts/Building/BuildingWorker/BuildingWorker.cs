using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorker : BaseBuilding
{

    protected static PlayerResources playerResources;
    protected Renderer renderer;
    protected Material material;
    public static string selectionOutlineShaderName = "TSF/BaseOutline1";
    protected float secondsOfUpdate = 3.0f;
    protected  int level = 0;
    public  int Level
    {
        get { return level;}
    }
    protected bool selected = false;
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }

    protected  int cost = 50;
    public  int Cost
    {
        get { return cost; }
    }
    private void Awake()
    {
        renderer = this.GetComponent<Renderer>();
        material = new Material(renderer.material);
        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
    }
    private void Update()
    {


    }
    public virtual void Upgrade()
    {

    }
    public void SelectionUpdate()
    {
        if (selected)
        {

            OnSelection();
        }
        else
        {
            Deselect();
        }
    }
    public void OnSelection()
    {
        renderer.material.shader = Shader.Find(selectionOutlineShaderName);
    }
    public void Deselect()
    {
        renderer.material = material;
    }
    protected int generateGoldPerSecond;

    
}

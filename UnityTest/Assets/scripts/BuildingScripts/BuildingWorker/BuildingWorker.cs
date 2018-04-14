using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWorker : MonoBehaviour
{
    protected static PlayerResources playerResources;
    protected int generateGoldPerSecond;
    protected float secondsOfUpdate = 3.0f;
    protected bool selected = false;
    protected Renderer renderer;
    protected Material material;
    public static string selectionOutlineShaderName = "TSF/BaseOutline1";
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }

    public int cost;

    public int Cost
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
    public void SelectionUpdate()
    {
        if (selected)
        {
            Debug.Log("Selected rendering...");
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
}

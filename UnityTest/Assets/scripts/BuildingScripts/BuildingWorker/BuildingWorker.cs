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
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }

    public static int cost;

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
            OnSelection();
        }
        else
        {
            Deselect();
        }
    }
    public void OnSelection()
    {
        renderer.material.shader = Shader.Find("Outlined/Custom Camera Independent");
    }
    public void Deselect()
    {
        renderer.material = material;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower : BaseBuilding {


    protected static PlayerResources playerResources;
    protected Renderer renderer;
    protected Material material;
    public static string selectionOutlineShaderName = "TSF/BaseOutline1";
    protected float secondsOfUpdate;
    protected bool selected = false;
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

    public virtual void Attack(GameObject enemy)
    {

    }
}
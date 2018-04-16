﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHolder : MonoBehaviour {

    public List<GameObject> enemies;
    // Use this for initialization
    void Start () {
        enemies = new List<GameObject>();
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < list.Length; i++)
        {
            enemies.Add(list[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
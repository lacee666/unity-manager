using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour {

    private Transform playerCamera;
	// Use this for initialization
	void Start () {
        playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPosition = playerCamera.position;
        newPosition.y = transform.position.y;
        this.transform.position = newPosition;
	}
}

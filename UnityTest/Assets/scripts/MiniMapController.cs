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
        //MiniMapOnClick();
	}

    private void MiniMapOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked mouse0");
            Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log("Moving pcamera");
                playerCamera.position = new Vector3(hit.transform.position.x, playerCamera.position.y, hit.transform.position.z);
            }
            Debug.Log(hit.transform.gameObject.tag);
        }
    }
}

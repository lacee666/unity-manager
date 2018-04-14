using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour {

    public LayerMask buildingMask = 8;
    private GameObject focus;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 1000.0f, (1 << buildingMask.value)))
            {
                
                if (hit.collider.gameObject.tag.Equals("Building"))
                {

                    focus = hit.collider.gameObject;
                    focus.GetComponent<BuildingWorker>().Selected = true;
                    focus.GetComponent<BuildingWorker>().SelectionUpdate();

                }
            }
            else
            {

                if (focus != null)
                {
                    //Debug.Log("Deselected building");
                    focus.GetComponent<BuildingWorker>().Selected = false;
                    focus.GetComponent<BuildingWorker>().SelectionUpdate();
                }

            }
            return;
        }
        else if(!Input.GetKeyUp(KeyCode.Mouse1) && Input.anyKey)
        {
            if (focus != null)
            {

                focus.GetComponent<BuildingWorker>().Selected = false;
                focus.GetComponent<BuildingWorker>().SelectionUpdate();
            }
        }
    }

}

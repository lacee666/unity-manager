using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : MonoBehaviour {

    private Renderer renderer;
    private bool canSpawn = true;
    public bool CanSpawn
    {
        get { return canSpawn; }
        set { canSpawn = value; }
    }
	// Use this for initialization
	void Start () {
       renderer = this.GetComponent<Renderer>();
       
	}
	
	// Update is called once per frame
	void Update () {
        //Random random = new Random();
        //renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            renderer.material.color = Color.red;
            canSpawn = false;
           // Debug.Log("Exited a building");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            renderer.material.color = Color.green;
            canSpawn = true;
           // Debug.Log("Exited a building");
        }
    }
     */
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            renderer.material.color = Color.red;
            canSpawn = false;
            //Debug.Log("Entered a building");
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("Building"))
        {
            renderer.material.color = Color.green;
            canSpawn = true;
            //Debug.Log("Exited a building");
        }
    }
}

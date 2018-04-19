using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float cameraSpeed = 5.0f;
    private float remainingScreenPercentage= 2.5f;
    private float acceleration = 1.0f;
    private float maxAcceleration = 6.0f;

    private Vector3 forwardVector;
    private Vector3 rightVector;

	void Start () {
        //forwardVector = new Vector3(Mathf.Sqrt(2)/2.0f, 0, Mathf.Sqrt(2)/2.0f);
        forwardVector = new Vector3(1, 0, 1);
        forwardVector.Normalize();
        rightVector = new Vector3(1, 0, -1);
        rightVector.Normalize();
	}
	
    void LateUpdate(){

        MouseMovement();
        CursorMovement();
        //acceleration = 1.0f;
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -15.0f, 15.0f),transform.position.y, Mathf.Clamp(transform.position.z, -20.0f, 11.0f));
    }

    
    private void CursorMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        if (horizontal > 0)
        {
            Move(rightVector);
        }
        else if (horizontal < 0)
        {
            Move(-1 * rightVector);
        }
        if (vertical > 0)
        {
            Move(forwardVector);
        }
        else if (vertical < 0)
        {
            Move(-1 * forwardVector);
        }
    }

    private void MouseMovement()
    {
        if (Input.mousePosition.x <= (Screen.width / 100.0f) * (remainingScreenPercentage))
        {
            //acceleration = 1.0f / Input.mousePosition.x;
            //acceleration = Mathf.Clamp(acceleration, 1.0f, maxAcceleration);
            Move(-1 * rightVector);
        }
        if (Input.mousePosition.x >= Screen.width / 100.0f * (100 - remainingScreenPercentage))
        {
            Move(rightVector);
        }
        if (Input.mousePosition.y <= (Screen.height / 100.0f) * (remainingScreenPercentage))
        {
            //acceleration = 0.3f / Input.mousePosition.y;
            //acceleration = Mathf.Clamp(acceleration, 1.0f, maxAcceleration);
            Move(-1 * forwardVector);
        }
        if (Input.mousePosition.y >= (Screen.height / 100.0f) * (100 - remainingScreenPercentage))
        {
            Move(forwardVector);
        }
    }

    private void Move(Vector3 direction)
    {
        this.transform.Translate(direction * cameraSpeed /** acceleration*/ * Time.deltaTime, Space.World);
    }
}

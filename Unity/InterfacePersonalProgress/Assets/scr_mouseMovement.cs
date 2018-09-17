using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mouseMovement : MonoBehaviour {

    // Initialize the public variables
    public float mouseSensitivityX;
    public float mouseSensitivityY;

    // Initialize the private variables
    private float speedRight;
    private float speedUp;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Capture the mouse input and apply it to the current speed
        speedRight = (Input.GetAxis("Mouse X") * mouseSensitivityX) * Time.deltaTime;
        speedUp = (Input.GetAxis("Mouse Y") * mouseSensitivityY) * Time.deltaTime;

        // Apply the speed to the current position
        transform.position += (transform.right * speedRight) + (transform.up * speedUp);
    }
}

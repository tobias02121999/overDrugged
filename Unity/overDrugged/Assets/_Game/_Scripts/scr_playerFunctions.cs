using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerFunctions : MonoBehaviour {

    // Initialize the private variables
    private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start ()
    {
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Move the player around based on the given arguments
    public void playerMovement(string inputHorizontal, string inputVertical, float speed)
    {
        // Convert the given input axis to a rotation value
        float rotationY = (Mathf.Atan2(Input.GetAxis(inputHorizontal), Input.GetAxis(inputVertical))) * Mathf.Rad2Deg;

        // Check if movement input is being given
        if (Mathf.Abs(Input.GetAxis(inputHorizontal)) != 0f || Mathf.Abs(Input.GetAxis(inputVertical)) != 0f)
        {
            Vector3 v3 = (transform.forward * speed) * Time.deltaTime; // Calculate the velocity required to move the player
            v3.y = playerRigidbody.velocity.y; // Reset the players rigidbody Y position back to default to include gravity in the process
            playerRigidbody.velocity = v3; // Apply the calculated velocity to the players rigidbody velocity

            // Apply the converted rotation to the players rigidbody
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);
        }   
    }
}

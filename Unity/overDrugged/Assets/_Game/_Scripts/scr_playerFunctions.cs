using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerFunctions : MonoBehaviour {

    // Initialize the public variables
    public GameObject playerInteractionHitbox;
    public Transform playerItemTransform;

    // Initialize the private variables
    private Rigidbody playerRigidbody;
    private scr_isColliding playerInteractionHitboxIsColliding;

	// Use this for initialization
	void Start ()
    {
        // Link the player rigidbody to a variable
        playerRigidbody = GetComponent<Rigidbody>();

        // Link the player interaction hitbox colliding script to a variable
        playerInteractionHitboxIsColliding = GetComponentInChildren<scr_isColliding>();
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

    // Pick up an item if the given conditions are met
    public void playerItemPickup(string inputItemPickup, bool isHolding)
    {
        // Pick up an item if it's in range, the corresponding button is being pressed and the player isn't currently holding anything already
        if (!isHolding && Input.GetAxis(inputItemPickup) != 0f && playerInteractionHitboxIsColliding.isColliding && playerInteractionHitboxIsColliding.collidingObject.GetComponent<scr_item>() != null)
        {
            playerInteractionHitboxIsColliding.collidingObject.GetComponent<Rigidbody>().isKinematic = true; // Make the item kinematic (disables most of the physics aspects)
            playerInteractionHitboxIsColliding.collidingObject.GetComponent<BoxCollider>().enabled = false; // Disable the items box collider

            playerInteractionHitboxIsColliding.collidingObject.GetComponent<Transform>().position = playerItemTransform.position; // Equal the items position to that of the players item transform (where his/her hands are)
            playerInteractionHitboxIsColliding.collidingObject.transform.SetParent(playerItemTransform); // Child the item to the players item transform

            GetComponent<scr_playerStats>().isHolding = true; // Notify the player that it's currently holding an item
        }
    }

    // Drop an item if the given conditions are met
    public void playerItemDrop(string inputItemDrop, bool isHolding)
    {
        // Drop an item if one is being held and the corresponding button is being pressed
        if (isHolding && Input.GetAxis(inputItemDrop) != 0f)
        {
            GetComponentInChildren<scr_item>().GetComponent<Rigidbody>().isKinematic = false; // Make the item non-kinematic (enables most of the physics aspects)
            GetComponentInChildren<scr_item>().GetComponent<BoxCollider>().enabled = true; // Enable the items box collider

            GetComponentInChildren<scr_item>().transform.parent = null; // Disconnect the item from it's current parent

            GetComponent<scr_playerStats>().isHolding = false; // Notify the player that it's currently not holding an item
        }
    }
}

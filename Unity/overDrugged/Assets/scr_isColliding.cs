using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_isColliding : MonoBehaviour {

    // This script can be used to detect collision, and check collisions of other objects from an external script

    // Initialize the public variables
    [HideInInspector]
    public bool isColliding;

    [HideInInspector]
    public GameObject collidingObject;

    // OnTriggerStay is called once per frame if trigger collision is detected
    void OnTriggerStay(Collider other)
    {
        // Tell the object that it is currently colliding
        isColliding = true;

        // Store the object it's colliding with inside of a variable
        collidingObject = other.gameObject;
    }

    // OnTriggerExit is called one frame after trigger collision was detected
    void OnTriggerExit(Collider other)
    {
        // Tell the object that it is currently not colliding anymore
        isColliding = false;
    }
}

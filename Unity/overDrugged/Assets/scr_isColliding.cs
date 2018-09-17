using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_isColliding : MonoBehaviour {

    // Initialize the public variables
    [HideInInspector]
    public bool isColliding;

    [HideInInspector]
    public GameObject collidingObject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider other)
    {
        isColliding = true;
        collidingObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}

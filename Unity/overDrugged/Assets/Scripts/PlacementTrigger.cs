using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTrigger : MonoBehaviour {

    private bool activateTrigger = false;

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag != "collectable" || !activateTrigger) return;

        Transform player = other.transform.parent.parent;
        player.GetComponent<PickUp>().placementObject = transform;
        //Debug.Log("Object can be placed on: " + transform.name);
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.tag != "collectable") return;

        activateTrigger = true;
        Transform player = other.transform.parent.parent;
        player.GetComponent<PickUp>().placementObject = null;
        //Debug.Log("Can't place object");
	}
}

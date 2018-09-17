using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    Player player;
    Transform pickupParent;
    LayerMask collectableMask;
    LayerMask placementMask;
    Transform pickupObject;

    public Transform placementObject; // placement trigger
    public float maxPickupDistance;

	// Use this for initialization
	void Start () {
        // to set layer, go to Edit -> Project Settings -> Tags and Layers
        // then, set collectable to have this layer
        collectableMask = 1 << 9;
        placementMask = 1 << 10;

        player = GetComponent<Player>();
        pickupParent = transform.GetChild(2);

        pickupObject = null;
        placementObject = null;
	}
	
	// Update is called once per frame
	void Update () {

        if (player.IsCarrying)
        {
            handlePutDown();
        }

        else 
        {
            handlePickup();
        }

    }

    // checks for nearby collectables and picks it up if player presses space
    void handlePickup()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20, collectableMask);

        if (colliders.Length == 0) return;

        foreach (Collider c in colliders)
        {
            // set "close proximity" texture / animation
            Debug.Log(c.name);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider collectable = getFacingCollectable(colliders);
            if (!collectable)
                return;

            collectable.transform.position = pickupParent.position;
            collectable.transform.rotation = pickupParent.rotation;

            collectable.gameObject.transform.SetParent(pickupParent);
            pickupObject = collectable.transform;
            player.IsCarrying = true;
        }
    }

    // checks for nearby place down points, place down if space pressed
    void handlePutDown()
    {
        if (placementObject == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pickupObject.SetParent(null);
            player.IsCarrying = false;

            //Debug.Log("placed down");
        }    
    }

    // returns collectable collider which the player is facing
    // returns null if player doesn't face any collectable (based on
    // threshold value)
    Collider getFacingCollectable(Collider[] colliders)
    {
        Collider closestCollider = null;
        float minDist = float.MaxValue;

        foreach(Collider c in colliders)
        {
            Vector3 dirToCollectable = (c.transform.position - transform.position).normalized;
            float distance = (dirToCollectable - transform.forward).magnitude;

            if (distance < minDist)
            {
                minDist = distance;
                closestCollider = c;
            }
        }

        if (minDist > maxPickupDistance) 
            return null;

        return closestCollider;
    }


}

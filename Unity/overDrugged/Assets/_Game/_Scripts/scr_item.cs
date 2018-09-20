using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item : MonoBehaviour {

    // This script does basically nothing, it is used to detect which child of the player is an item (kinda like the way a tag would function)

    // Initialize the public variables
    public bool isFood;

    void OnCollisionEnter(Collision collision)
    {
        if (isFood && collision.gameObject.GetComponent<scr_itemSurface>() != null)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
            transform.position = collision.gameObject.GetComponent<scr_itemSurface>().itemTransform.position;
            transform.SetParent(collision.gameObject.GetComponent<scr_itemSurface>().itemTransform);
        }
    }
}

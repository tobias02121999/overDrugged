using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
   	}
	
	// Update is called once per frame
	void Update () {

        // update orientation
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1 * rotateSpeed, 0)); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1 * rotateSpeed, 0));
        }

        // update position
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right.normalized * moveSpeed;
        }
	}

    // sets player orientation to mouse location, returns direction vector
    /*private void lookatMouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500))
        {
            Vector3 direction = hit.point - transform.position;
            direction.Normalize();

            transform.forward = new Vector3(direction.x, 0, direction.z);
        }
    }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isCarrying;

    public bool IsCarrying
    {
        get { return isCarrying; }
        set { isCarrying = value; }
    }


	// Use this for initialization
	void Start () {
        isCarrying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

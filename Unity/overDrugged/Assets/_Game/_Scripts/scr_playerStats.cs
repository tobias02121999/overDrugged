using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerStats : MonoBehaviour {

    // This script is used to initialize the player statistics, to keep things structurized and neat

    // Initialize the public variables
    public string inputAxisHorizontal;
    public string inputAxisVertical;
    public string inputButtonItemPickup;
    public string inputButtonItemDrop;
    public float movementSpeed;

    [HideInInspector]
    public bool isHolding;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerStates : MonoBehaviour {

    // Initialize the private variables
    private scr_playerFunctions playerFunctions;
    private scr_playerStats playerStats;
    private string playerState = "NEUTRAL";

	// Use this for initialization
	void Start ()
    {
        // Link the player functions script to a variable
        playerFunctions = GetComponent<scr_playerFunctions>();

        // Link the player stats script to a variable
        playerStats = GetComponent<scr_playerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Run the player state function
        runState(playerState);
	}

    // Run the player state according to the given argument
    void runState(string stateName)
    {
        // Scroll through all of the player states, and run the functions corresponding to the given state name
        switch (stateName)
        {
            // The default player state
            case "DEFAULT":

                break;
        }
    }
}

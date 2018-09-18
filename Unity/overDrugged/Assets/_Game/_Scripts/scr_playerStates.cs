using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the player states and store them inside of an enum
enum states { DEFAULT }

public class scr_playerStates : MonoBehaviour {

    // Initialize the private variables
    private scr_playerFunctions playerFunctions;
    private scr_playerStats playerStats;
    private states playerState = states.DEFAULT;

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
    void runState(states stateName)
    {
        // Scroll through all of the player states, and run the functions corresponding to the given state name
        switch (stateName)
        {
            // The default player state
            case states.DEFAULT:

                // Run the player movement function
                playerFunctions.playerMovement(playerStats.inputAxisHorizontal, playerStats.inputAxisVertical, playerStats.movementSpeed);

                // Run the player item pickup function
                playerFunctions.playerItemPickup(playerStats.inputButtonItemPickup, playerStats.isHolding);

                // Run the player item drop function
                playerFunctions.playerItemDrop(playerStats.inputButtonItemDrop, playerStats.isHolding);

                break;
        }
    }
}

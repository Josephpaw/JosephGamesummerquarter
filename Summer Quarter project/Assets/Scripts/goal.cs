using UnityEngine;

public class goal : MonoBehaviour
{
    // Private variable of type int to track how many poitns the goal give
    private int pointValue = 1;   

    // this function is called any time another collider enters this goal's collider trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check If the player hit the goal
        // Variable of type PlayerController named player
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        // If the player did hit the goal:
        if(player != null)
        {
            // Reset The Stage
            // Earn Points
            // Play A sound Effect
            Debug.Log("We Scored!");
        }
        
    }
}


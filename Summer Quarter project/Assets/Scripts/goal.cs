using UnityEngine;
using TMPro; // Include the TextMesh Pro namespace

public class goal : MonoBehaviour
{
    // Private variable of type int to track how many poitns the goal give
    private int PointValue = 1;   

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


public class Goal : MonoBehaviour
{
    // How many points the goal is worth
    private int PointValue = 1;

    // Drag your TextMeshPro object here in the Inspector
    public TMP_Text goalText;

    void Start()
    {
        // Hide the text when the game starts
        goalText.gameObject.SetActive(false);
    }

    // Called when something enters the goal
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("We Scored!");

            // Show the text
            goalText.gameObject.SetActive(true);
            goalText.text = "GOOOOOAL!";
        }
    }
}
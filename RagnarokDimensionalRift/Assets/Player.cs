using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        //Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.LogError("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        //Debug.Log("Player script initialization complete."); // Add this line
    }

    public void SummonGod()
    {
        // Load the icon sprite (you can set this in the Unity Editor)
        Sprite godIcon = Resources.Load<Sprite>("GodIcons/CthulhuIcon"); 

        // Create a new god with a specified icon
        God newGod = new God("Cthulhu", 1, godIcon);
        gameController.allSummonedGods.Add(newGod);
    }

    // Additional methods for handling the inventory
}

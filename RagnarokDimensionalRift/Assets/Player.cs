using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;

        Debug.Log("Player script initialization complete."); // Add this line
    }

    public void SummonGod()
    {
        // Instantiate a new GameObject for the summoned god
        GameObject godObject = new GameObject("Cthulhu");

        // Attach a God component to the newly created GameObject
        God newGod = godObject.AddComponent<God>();
        newGod.godName = "Cthulhu";
        newGod.powerLevel = 50;

        // Add the newly summoned god to the GameController
        gameController.allSummonedGods.Add(newGod);
    }

    // Additional methods for handling the inventory
}

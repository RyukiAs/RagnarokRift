using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGrade : MonoBehaviour
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


    public void setGrade(int grade)
    {
        gameController.SetActiveGrade(grade);
    }

    
}

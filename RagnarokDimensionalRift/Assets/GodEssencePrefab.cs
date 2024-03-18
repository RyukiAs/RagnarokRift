using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodEssencePrefab : MonoBehaviour
{

    [SerializeField]
    private God godPass;

    private GameController gameController;

    private void Start()
    {
        //Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        //Debug.Log("Player script initialization complete."); // Add this line
    }

    public void SetGodInfo(God god)
    {
        this.godPass = god;
    }

    public void addGodToList()
    {
        gameController.GetAllEssenceGods().Add(this.godPass);
    }

}

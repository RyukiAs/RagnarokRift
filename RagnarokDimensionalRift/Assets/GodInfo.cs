using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodInfo : MonoBehaviour
{ 
    [SerializeField]
    private God godPass;

    private GameController gameController;

    private void OnEnable()
    {
        // Initialize the GameController reference
        gameController = GameController.Instance;

        // Get the tapped god from GameController
        godPass = gameController.getTappedGod();

    }

    public void upgradeGod()
    {
        godPass.level += 1;
    }

}

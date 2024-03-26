using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon10x : MonoBehaviour
{
    private GameController gameController;

    public List<God> summonedGods;

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
    }

    private void OnEnable()
    {
        StartCoroutine(showSummonGod());
    }

    private IEnumerator showSummonGod()
    {
        while (gameController == null || gameController.GetAllSummonedGods() == null)
        {
            yield return null; // Wait for the next frame
        }

        // Once the condensed god is set, proceed with displaying the god icons
        List<God> allGods= gameController.GetAllSummonedGods();
        int godCount = gameController.GetAllSummonedGods().Count;
        for(int i = godCount-10; i <godCount; i++)
        {
            summonedGods.Add(allGods[i]);
        }
        UpdateScreen();
    }

    private void UpdateScreen()
    {
        foreach(God god in summonedGods)
        {
            Debug.Log("Summoned " + god.godName);
        }
    }

}

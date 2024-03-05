using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<God> allSummonedGods = new List<God>();

    // Singleton pattern to ensure only one instance of GameController exists
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameController");
                instance = go.AddComponent<GameController>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    public List<God> GetAllSummonedGods()
    {
        return allSummonedGods;
    }

    private void Awake()
    {
        Debug.Log("Awake called in GameController."); // Add this line

        if (instance != null && instance != this)
        {
            Debug.Log("Another instance already exists. Destroying current instance."); // Add this line
            Destroy(gameObject);
            return;
        }

        Debug.Log("Setting GameController instance."); // Add this line
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

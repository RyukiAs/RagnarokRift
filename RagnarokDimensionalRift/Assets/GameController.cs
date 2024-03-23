using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //list of all gods
    public List<God> allSummonedGods = new List<God>();

    public God TappedGod;

    //used in EssenceOfGods
    public int ActiveGrade = 1;
    public List<God> EssenceList = new List<God>();
    public List<GameObject> ListEssencePrefabs = new List<GameObject>();
    public God CondensedGod;

    //used in Labors
    public int Trial = 1;
    public List<God> LaborsGodList = new List<God>();
    public List<GameObject> ListLaborsPrefabs = new List<GameObject>();
    public God LaborEnemy;

    //public GameObject ConfirmButton;

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

    public int GetTrial()
    {
        return Trial;
    }

    public void SetTrial(int num)
    {
        Trial = num;
    }

    public List<God> GetLaborGods()
    {
        return LaborsGodList;
    }

    public void WipeLaborGods()
    {
        LaborsGodList.Clear();
    }
    public List<GameObject> GetListLaborPrefabs()
    {
        return ListLaborsPrefabs;
    }

    public void WipeListLaborsPrefabs()
    {
        ListLaborsPrefabs.Clear();
    }

    public List<God> GetAllSummonedGods()
    {
        return allSummonedGods;
    }

    public God GetCondensedGod()
    {
        return CondensedGod;
    }

    public void SetCondensedGod(God god)
    {
        CondensedGod = god;
    }

    public List<GameObject> GetListEssencePrefabs()
    {
        return ListEssencePrefabs;
    }

    public void WipeListEssencePrefabs()
    {
        ListEssencePrefabs.Clear();
    }

    public int GetActiveGrade()
    {
        return ActiveGrade;
    }

    public void SetActiveGrade(int grade)
    {
        ActiveGrade = grade;
    }

    public List<God> GetAllEssenceGods()
    {
        return EssenceList;
    }

    public void WipeAllEssenceGods()
    {
        EssenceList.Clear();
    }

    public void SetTappedGod(God god)
    {
        // Set the TappedGod property
        TappedGod = god;
    }

    public void UpgradeGrade(God god)
    {
        god.grade += 1;
    }

    public God getTappedGod()
    {
        return TappedGod;
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

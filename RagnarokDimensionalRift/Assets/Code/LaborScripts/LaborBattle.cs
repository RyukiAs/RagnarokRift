using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaborBattle : MonoBehaviour
{
    private GameController gameController;

    private AttackManager attackManager;
    [SerializeField]
    private GameObject godIconPrefab;

    [SerializeField]
    private Transform iconsParent;

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        attackManager = GetComponent<AttackManager>();
        if(attackManager == null)
        {
            Debug.LogError("AttackManage component not found.");
            return;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(WaitForGod());
        //showGods();
    }

    private IEnumerator WaitForGod()
    {
        while (gameController == null || gameController.GetLaborGods() == null || gameController.LaborEnemy == null)
        {
            yield return null; // Wait for the next frame
        }

        showGods();

    }

    private void OnDisable()
    {
        Transform parentTransform = this.transform;

        foreach (Transform child in parentTransform)
        {
            if (!child.CompareTag("Player"))
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void showGods()
    {
        foreach (God god in gameController.GetLaborGods())
        {
            GameObject godIcon = Instantiate(godIconPrefab, iconsParent);
            gameController.ListLaborsPrefabs.Add(godIcon);
            RectTransform godIconRectTransform = godIcon.GetComponent<RectTransform>();
            godIconRectTransform.anchoredPosition = god.position;
            Image godSprite = godIcon.GetComponentInChildren<Image>();
            godSprite.sprite = god.sprite;
            SetGodOnPrefab script = godIcon.GetComponent<SetGodOnPrefab>();
            script.setGod(god);
        }

        God enemyGod = gameController.LaborEnemy;
        GameObject enemyPrefab = Instantiate(godIconPrefab, iconsParent);
        gameController.ListEnemyLaborsPrefabs.Add(enemyPrefab);
        RectTransform enemyGodRectTransform = enemyPrefab.GetComponent<RectTransform>();
        enemyGodRectTransform.anchoredPosition = enemyGod.position;
        Image enemyGodSprite = enemyPrefab.GetComponentInChildren<Image>();
        enemyGodSprite.sprite = enemyGod.sprite;
        SetGodOnPrefab script2 = enemyPrefab.GetComponent<SetGodOnPrefab>();
        script2.setGod(enemyGod);

        List<GameObject> PlayerTeam = gameController.GetListLaborPrefabs();
        List<GameObject> LaborTeam = gameController.GetListEnemyLaborPrefabs();

        foreach(GameObject prefab in PlayerTeam)
        {
            SetGodOnPrefab script3 = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script3.getGod();
            Debug.Log($"Found {prefabGod.godName} in PlayerTeam");
        }
        foreach (GameObject prefab in LaborTeam)
        {
            SetGodOnPrefab script3 = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script3.getGod();
            Debug.Log($"Found {prefabGod.godName} in LaborTeam");
        }
        Canvas canvas = this.GetComponentInParent<Canvas>();
        attackManager.StartBattle(PlayerTeam, LaborTeam, canvas);
        //StartCoroutine(Battle());
    }
    

}


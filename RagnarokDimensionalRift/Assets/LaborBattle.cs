using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaborBattle : MonoBehaviour
{
    private GameController gameController;

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
    }

    private void OnEnable()
    {
        showGods();
    }

    private void OnDisable()
    {
        Transform parentTransform = this.transform;

        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
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
        }

        God enemyGod = gameController.LaborEnemy;
        GameObject enemyPrefab = Instantiate(godIconPrefab, iconsParent);
        gameController.ListEnemyLaborsPrefabs.Add(enemyPrefab);
        RectTransform enemyGodRectTransform = enemyPrefab.GetComponent<RectTransform>();
        enemyGodRectTransform.anchoredPosition = enemyGod.position;
        Image enemyGodSprite = enemyPrefab.GetComponentInChildren<Image>();
        enemyGodSprite.sprite = enemyGod.sprite;
        Battle();
    }

    public void Battle()
    {
        Debug.Log("Battling");
        int godAmount = gameController.GetLaborGods().Count;
        List<God> list = gameController.GetLaborGods();
        List<GameObject> listPrefabs = gameController.GetListLaborPrefabs();
        List<GameObject> listEnemyPrefabs = gameController.GetListEnemyLaborPrefabs();
        God enemyGod = gameController.LaborEnemy;
        bool battle = true;
        while(battle)
        {
            for (int i = 0; i < list.Count; i++)
            {
                //battle = list[i].InitiateAttack(list[i], enemyGod, listPrefabs[i], listEnemyPrefabs[0]);
                list[i].InitiateAttack(list[i], enemyGod, listPrefabs[i], listEnemyPrefabs[0]);
                Debug.Log(battle);
            }
        }
        
        
    }
}

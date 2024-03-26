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

        // Once the condensed god is set, proceed with displaying the god icons
        //is.godPass = gameController.GetCondensedGod();
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




        attackManager.StartBattle();
        //StartCoroutine(Battle());
    }
    

}


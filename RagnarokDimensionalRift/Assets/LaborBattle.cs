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
        StartCoroutine(Battle());
    }
    /*
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
                AttackManager.MoveAndAttack(list[i], enemyGod, listPrefabs[i], listEnemyPrefabs[0]);
                if(enemyGod.health < 1)
                {
                    battle = false;
                }else
                {
                    battle = true;
                }
                Debug.Log(battle);
            }
        }
        */
    public IEnumerator Battle()
    {
        Debug.Log("Battling");

        List<God> attackingGods = gameController.GetLaborGods();
        List<GameObject> attackingPrefabs = gameController.GetListLaborPrefabs();
        List<GameObject> defendingPrefabs = gameController.GetListEnemyLaborPrefabs();
        God enemyGod = gameController.LaborEnemy;

        bool battleInProgress = true;

        while (battleInProgress)
        {
            battleInProgress = false; // Assume battle ends unless an attack is initiated

            for (int i = 0; i < attackingGods.Count; i++)
            {
                if (attackingGods[i].health > 0 && enemyGod.health > 0)
                {
                    // Initiate attack for each attacking god
                    yield return MoveAndAttack(attackingGods[i], enemyGod, attackingPrefabs[i], defendingPrefabs[0]);

                    // Check if battle is still in progress
                    if (enemyGod.health > 0)
                    {
                        battleInProgress = true;
                    }
                }
            }
            yield return MoveAndAttack(enemyGod, attackingGods[0], defendingPrefabs[0], attackingPrefabs[0]);
        }

        Debug.Log("Battle ended.");
    }

    private IEnumerator MoveAndAttack(God attackingGod, God defendingGod, GameObject attackingPrefab, GameObject defendingPrefab)
    {
        Vector3 initialPosition = attackingPrefab.transform.position;
        Vector3 offset = new Vector3(30f, 0f, 0f);
        Vector3 targetPosition = defendingPrefab.transform.position - offset;
        Vector3 returnPosition = initialPosition;

        float moveDuration = 1f;
        float elapsedTime = 0f;

        // Move attacking prefab towards target position
        while (elapsedTime < moveDuration)
        {
            attackingPrefab.transform.position = Vector3.Lerp(attackingPrefab.transform.position, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure attacking prefab reaches the target position
        attackingPrefab.transform.position = targetPosition;

        // Perform attack
        Attack(attackingGod, defendingGod);

        //Image sprite = defendingPrefab.GetComponent<Image>();
        //sprite.color = Color.red;
        // Get the sprite renderer component of the defending prefab
        Transform imageObj = defendingPrefab.transform.Find("Image");
        Image defendingImage = imageObj.GetComponent<Image>();

        // Store the original color of the defending prefab
        Color originalColor = defendingImage.color;

        // Change the color of the defending prefab to red temporarily
        defendingImage.color = Color.red;
        // Wait for a short delay after the attack
        //yield return new WaitForSeconds(0.5f);

        // Move back to the initial position
        elapsedTime = 0f;
        moveDuration = 1f;
        while (elapsedTime < moveDuration)
        {
            attackingPrefab.transform.position = Vector3.Lerp(targetPosition, returnPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        defendingImage.color = originalColor;
        //sprite.color = Color.red;

        // Ensure it returns to the initial position
        attackingPrefab.transform.position = returnPosition;
    }

    private void Attack(God attackingGod, God defendingGod)
    {
        int damage = attackingGod.attack - defendingGod.defense;
        if (damage > 0)
        {
            defendingGod.health -= damage;
            Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName} for {damage} damage.");
        }
        else
        {
            Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName}, but no damage is dealt.");
        }
    }

}


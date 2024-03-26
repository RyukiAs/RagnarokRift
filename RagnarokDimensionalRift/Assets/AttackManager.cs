using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    private GameController gameController;

    private bool canAttack = true; // Flag to track if a god can attack
    private float cooldownDuration = 1f; // Cooldown duration in seconds
    private float offsetDuration = 0.1f; // Offset duration between attacks in seconds

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
    }

    public void StartBattle()
    {
        StartCoroutine(Battle());
    }
    /*
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
    */
    private IEnumerator Cooldown(God god)
    {
        yield return new WaitForSeconds(cooldownDuration);
        canAttack = true; // Reset canAttack flag after cooldown
    }
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
            //battleInProgress = false; // Assume battle ends unless an attack is initiated

            for (int i = 0; i < attackingGods.Count; i++)
            {
                if (attackingGods[i].health > 0 && enemyGod.health > 0 && canAttack)
                {
                    // Initiate attack for each attacking god
                    StartCoroutine(MoveAndAttack(attackingGods[i], enemyGod, attackingPrefabs[i], defendingPrefabs[0]));

                    // Set canAttack to false and start cooldown
                    attackingGods[i].canAttack = false;
                    StartCoroutine(Cooldown(attackingGods[i]));

                    // Set battle in progress flag to true
                    battleInProgress = true;

                    // Wait for offset duration before next attack
                    yield return new WaitForSeconds(offsetDuration);
                }
            }

            // Check if enemy god is defeated
            if (enemyGod.health <= 0)
            {
                battleInProgress = false;
                Debug.Log("Enemy god defeated.");
                break;
            }

            // Wait for all attacks to finish
            yield return new WaitForSeconds(offsetDuration);
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

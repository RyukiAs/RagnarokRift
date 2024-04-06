using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class AttackManager : MonoBehaviour
{
    private GameController gameController;

    private float cooldownDuration = 1f; // Cooldown duration in seconds
    private float offsetDuration = 0.1f; // Offset duration between attacks in seconds
    private List<GameObject> Team1Prefabs = new List<GameObject>();
    private List<GameObject> Team2Prefabs = new List<GameObject>();
    private List<GameObject> Holder = new List<GameObject>();

    private List<GameObject> AttackOrderPrefabs = new List<GameObject>();
    private List<GameObject> Team1AttackOrderPrefabs= new List<GameObject>();
    private List<GameObject> Team2AttackOrderPrefabs = new List<GameObject>();
    private GameObject attackPrefab;
    private GameObject defendPrefab;
    private List<God> AttackOrderGods = new List<God>();
    private List<God> team1Gods = new List<God>();
    private List<God> team2Gods = new List<God>();
    //private List<God> 

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }

    }

    public void StartBattle(List<GameObject> team1, List<GameObject> team2)
    {
        AttackOrderPrefabs.Clear();
        AttackOrderGods.Clear();
        team1Gods.Clear();
        team2Gods.Clear();

        Team1Prefabs = team1;
        Team2Prefabs = team2;

        foreach (GameObject prefab in Team1Prefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God god = script.getGod();
            if (god != null)
            {
                team1Gods.Add(god);
            }
        }

        // Extract the God component from each prefab in team2Prefabs
        foreach (GameObject prefab in Team2Prefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God god = script.getGod();
            if (god != null)
            {
                team2Gods.Add(god);
            }
        }
        Holder = Team1Prefabs;
        foreach (GameObject prefab in Team2Prefabs)
        {
            Holder.Add(prefab);
        }
        SortPrefabsByXPosition();

        StartCoroutine(startFight());
    }

    private void SortPrefabsByXPosition()
    {
        // Clear previous data
        Team1AttackOrderPrefabs.Clear();
        Team2AttackOrderPrefabs.Clear();
        Holder.Clear();

        // Dictionary to store prefab and its distance from X position 0
        Dictionary<GameObject, float> prefabDistanceMap = new Dictionary<GameObject, float>();

        // Calculate the distance of each prefab's X position from 0 and store in the dictionary
        foreach (GameObject prefab in Team1Prefabs)
        {
            float distance = Mathf.Abs(prefab.transform.position.x);
            prefabDistanceMap.Add(prefab, distance);
        }

        foreach (GameObject prefab in Team2Prefabs)
        {
            float distance = Mathf.Abs(prefab.transform.position.x);
            prefabDistanceMap.Add(prefab, distance);
        }

        // Sort the dictionary by distance
        var sortedDict = prefabDistanceMap.OrderBy(x => x.Value);

        // Add the sorted prefabs to the global variables
        foreach (var entry in sortedDict)
        {
            Holder.Add(entry.Key);
            if (Team1Prefabs.Contains(entry.Key))
            {
                Team1AttackOrderPrefabs.Add(entry.Key);
            }
            else if (Team2Prefabs.Contains(entry.Key))
            {
                Team2AttackOrderPrefabs.Add(entry.Key);
            }
        }
    }

    /*
    public IEnumerator SetAttack()
    {
        List<GameObject> attackOrder;
        int rand = Random.range(1,11)
        if(rand.range
    }
    */
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
            //battleInProgress = false; // Assume battle ends unless an attack is initiated

            for (int i = 0; i < attackingGods.Count; i++)
            {
                if (attackingGods[i].health > 0 && enemyGod.health > 0 && attackingGods[i].canAttack)
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
    */

    public IEnumerator startFight()
    {
        bool battleInProgress = true;

        int currentIndex = 0;
        int totalPrefabs = Holder.Count;

        while (battleInProgress)
        {
            // Get the next prefab to attack
            attackPrefab = Holder[currentIndex];
            SetGodOnPrefab script = attackPrefab.GetComponent<SetGodOnPrefab>();
            God godToAttack = script.getGod();
            //GameObject defendPrefab = new GameObject();

            if(godToAttack.health> 0)
            {
                bool attack = godToAttack.attacking;
                if(attack)
                {
                    foreach (GameObject prefab in Team2AttackOrderPrefabs)
                    {
                        SetGodOnPrefab defendScript = prefab.GetComponent<SetGodOnPrefab>();
                        God defendGod = defendScript.getGod();
                        if(defendGod.health > 0)
                        {
                            defendPrefab = prefab;
                            break;
                        }
                    }
                    
                }
                else
                {
                    foreach (GameObject prefab in Team1AttackOrderPrefabs)
                    {
                        SetGodOnPrefab defendScript = prefab.GetComponent<SetGodOnPrefab>();
                        God defendGod = defendScript.getGod();
                        if (defendGod.health > 0)
                        {
                            defendPrefab = prefab;
                            break;
                        }
                    }
                }

                // Initiate attack for the god
                StartCoroutine(Move());

                // Move to the next prefab in the list
                currentIndex = (currentIndex + 1) % totalPrefabs;

                // Wait for offset duration before next attack
                yield return new WaitForSeconds(offsetDuration);
                yield return null;
            }
            
        }
    }


    private IEnumerator Cooldown(God god)
    {
        yield return new WaitForSeconds(cooldownDuration);
        god.canAttack = true; // Reset canAttack flag after cooldown
    }

    private IEnumerator Move()
    {
        yield return null;
    }

    /*
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
    */

}

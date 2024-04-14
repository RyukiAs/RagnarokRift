using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class AttackManager : MonoBehaviour
{
    private GameController gameController;

    private Canvas canvas;

    private float cooldownDuration = 1f; // Cooldown duration in seconds
    private float offsetDuration = 3f; // Offset duration between attacks in seconds
    private List<GameObject> Team1Prefabs = new List<GameObject>();
    private List<GameObject> Team2Prefabs = new List<GameObject>();
    private List<GameObject> Holder = new List<GameObject>();

    private List<GameObject> AttackOrderPrefabs = new List<GameObject>();
    private List<GameObject> Team1AttackOrderPrefabs = new List<GameObject>();
    private List<GameObject> Team2AttackOrderPrefabs = new List<GameObject>();


    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }

    }

    public void StartBattle(List<GameObject> team1, List<GameObject> team2, Canvas canvasUse)
    {
        canvas = canvasUse;
        AttackOrderPrefabs.Clear();
        Holder.Clear();

        Team1Prefabs = team1;
        Team2Prefabs = team2;


        foreach (GameObject prefab in team1)
        {
            Holder.Add(prefab);
        }

        foreach (GameObject prefab in team2)
        {
            Holder.Add(prefab);
        }
        /*
        foreach (GameObject prefab in Holder)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Holder in setting");
        }
        

        foreach (GameObject prefab in Team1Prefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Team1Prefabs in setting");
        }

        foreach (GameObject prefab in Team2Prefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Team2Prefabs in setting");
        }
        */

        SortPrefabsByPosition();

        StartCoroutine(startFight());
    }

    private void SortPrefabsByPosition()
    {
        // Sort the prefabs based on their X positions
        Team1AttackOrderPrefabs.Clear();
        Team2AttackOrderPrefabs.Clear();

        Team1AttackOrderPrefabs = Team1Prefabs;
        Team2AttackOrderPrefabs = Team2Prefabs;

        Holder.Sort((a, b) => Mathf.Abs(a.transform.position.x).CompareTo(Mathf.Abs(b.transform.position.x)));
        Team1AttackOrderPrefabs.Sort((a, b) => Mathf.Abs(a.transform.position.x).CompareTo(Mathf.Abs(b.transform.position.x)));
        Team2AttackOrderPrefabs.Sort((a, b) => Mathf.Abs(a.transform.position.x).CompareTo(Mathf.Abs(b.transform.position.x)));

        foreach (GameObject prefab in Holder)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Holder:");
        }

        foreach (GameObject prefab in Team1AttackOrderPrefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Team1AttackOrderPrefabs:");
        }

        foreach (GameObject prefab in Team2AttackOrderPrefabs)
        {
            SetGodOnPrefab script = prefab.GetComponent<SetGodOnPrefab>();
            God prefabGod = script.getGod();
            Debug.Log($"Found {prefabGod.godName} in Team2AttackOrderPrefabs:");
        }

    }

    public IEnumerator startFight()
    {
        bool battleInProgress = true;

        int currentIndex = 0;
        int totalPrefabs = Holder.Count;

        while (battleInProgress)
        {
            // Get the next prefab to attack
            GameObject attackPrefab = Holder[currentIndex];
            GameObject defendPrefab;
            SetGodOnPrefab script = attackPrefab.GetComponent<SetGodOnPrefab>();
            God godToAttack = script.getGod();

            Debug.Log("Team1AttackOrderPrefabs count: " + Team1AttackOrderPrefabs.Count());
            Debug.Log("Team2AttackOrderPrefabs count: " + Team2AttackOrderPrefabs.Count());
            if (Team1AttackOrderPrefabs.Count() <= 0)
            {
                battleInProgress = false;
                Debug.Log("Defeat");
                yield break;
            }
            else if (Team2AttackOrderPrefabs.Count() <= 0)
            {
                battleInProgress = false;
                Debug.Log("Victory");
                yield break;
            }

            if (godToAttack.health > 0)
            {
                bool attack = godToAttack.attacking;
                if (attack)
                {
                    if (Team2AttackOrderPrefabs[0] != null)
                    {
                        defendPrefab = Team2AttackOrderPrefabs[0];
                    }
                    else if (Team2AttackOrderPrefabs.Count() <= 0)
                    {
                        defendPrefab = null;
                        battleInProgress = false;
                        Debug.Log("Victory");
                        yield break;
                    }
                    else
                    {
                        defendPrefab = null;
                        yield break;
                    }
                }
                else
                {
                    if (Team1AttackOrderPrefabs[0] != null)
                    {
                        defendPrefab = Team1AttackOrderPrefabs[0];
                    }
                    else if (Team1AttackOrderPrefabs.Count() <= 0)
                    {
                        defendPrefab = null;
                        battleInProgress = false;
                        Debug.Log("Defeat");
                        yield break;
                    }
                    else
                    {
                        defendPrefab = null;
                        yield break;
                    }
                }

                // Initiate attack for the god
                StartCoroutine(Move(attackPrefab, defendPrefab));

                // Move to the next prefab in the list
                currentIndex = (currentIndex + 1) % totalPrefabs;

                // Wait for offset duration before next attack
                yield return new WaitForSeconds(offsetDuration);
            }

        }
    }

    private IEnumerator Move(GameObject attackPrefab, GameObject defendPrefab)
    {
        // Initial and target positions
        Vector3 initialPosition = attackPrefab.transform.position;
        SetGodOnPrefab script = defendPrefab.GetComponent<SetGodOnPrefab>();
        God defendGod = script.getGod();
        Vector3 offset = defendGod.attacking ? new Vector3(30f, 0f, 0f) : new Vector3(-30f, 0f, 0f);

        Vector3 canvasScale = canvas.transform.localScale; // Get canvas scale
        Vector3 canvasCenter = canvas.transform.position;

        Vector3 targetPosition = new Vector3(canvasCenter.x + (canvasScale.x * offset.x) + (canvasScale.x * defendGod.position.x),
                                         canvasCenter.y + (canvasScale.y * offset.y) + (canvasScale.y * defendGod.position.y),
                                         0f);

        // Duration of the movement
        float moveDuration = 1f;
        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            // Calculate the next position towards the target
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, (elapsedTime / moveDuration));

            // Set the position of the attackPrefab
            attackPrefab.transform.position = newPosition;

            Debug.Log($"small move to {attackPrefab.transform.position}");

            elapsedTime += Time.deltaTime; // DEBUG: Math is causing sprites to go off screen

            Debug.Log($"elapsedTime = {elapsedTime}");
            yield return null; // Wait for the next frame
        }

        Debug.Log($"Before setting target pos: {attackPrefab.transform.position}");

        // Ensure the attackPrefab reaches the target position
        attackPrefab.transform.position = targetPosition;

        Debug.Log($"After setting target pos: {attackPrefab.transform.position}");


        //Debug.Log("Resetting position");
        //SetGodOnPrefab ascript = attackPrefab.GetComponent<SetGodOnPrefab>();
        //God aGod = ascript.getGod();
        //attackPrefab.transform.position = new Vector3(canvasCenter.x + (canvasScale.x * aGod.position.x), 
        //                                              canvasCenter.y + (canvasScale.y * aGod.position.y), 0f);
        Attack(attackPrefab, defendPrefab);

    }

    public void Attack(GameObject attackPrefab, GameObject defendPrefab)
    {
        SetGodOnPrefab attackingGodScript = attackPrefab.GetComponent<SetGodOnPrefab>();
        God attackingGod = attackingGodScript.getGod();

        SetGodOnPrefab defendingGodScript = defendPrefab.GetComponent<SetGodOnPrefab>();
        God defendingGod = defendingGodScript.getGod();

        int damage = attackingGod.attack - defendingGod.defense;
        if (damage > 0)
        {
            defendingGod.health -= damage;
            Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName} for {damage} damage.");
            if (defendingGod.health < 0)
            {
                //Holder.Remove(defendPrefab);
                if (defendingGod.attacking)
                {
                    Team1AttackOrderPrefabs.Remove(defendPrefab);
                }
                else
                {
                    Team2AttackOrderPrefabs.Remove(defendPrefab);
                }
                Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName} for {damage} damage and kills him.");
            }
        }
        else
        {
            Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName}, but no damage is dealt.");
        }
        StartCoroutine(AttackVisual(defendPrefab));
        StartCoroutine(MoveBack(attackPrefab));
    }

    private IEnumerator AttackVisual(GameObject defender)
    {
        Debug.Log("Inside AttackVisual");

        // Attempt to find the Image component on the defender object
        Image sprite = defender.GetComponentInChildren<Image>();

        // Check if the Image component is found
        if (sprite != null)
        {

            // Store the original color of the defending prefab
            Color originalColor = sprite.color;

            // Change the color of the defending prefab to red temporarily
            sprite.color = Color.red;

            //// Wait for a short delay after the attack
            yield return new WaitForSeconds(0.5f);

            // Restore the original color of the defending prefab
            sprite.color = originalColor;
        }
        else
        {
            Debug.Log("cannot find sprite");
        }

    }

    private IEnumerator MoveBack(GameObject attackPrefab)
    {
        Debug.Log("Moving back now!");


        // Initial and target positions
        Vector3 initialPosition = attackPrefab.transform.position;

        SetGodOnPrefab attackingGodScript = attackPrefab.GetComponent<SetGodOnPrefab>();
        God attackingGod = attackingGodScript.getGod();

        Vector3 canvasScale = canvas.transform.localScale; // Get canvas scale
        Vector3 canvasCenter = canvas.transform.position;

        Vector3 targetPosition = new Vector3(canvasCenter.x + (canvasScale.x * attackingGod.position.x),
                                         canvasCenter.y + (canvasScale.y * attackingGod.position.y),
                                         0f);

        Debug.Log($"targetPosition moving back to {targetPosition}");

        // Duration of the movement
        float moveDuration = 1f;

        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            // Calculate the next position towards the target
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, (elapsedTime / moveDuration));

            // Set the position of the attackPrefab
            attackPrefab.transform.position = newPosition;

            Debug.Log($"small move back to {attackPrefab.transform.position}");

            elapsedTime += Time.deltaTime;
            Debug.Log($"elapsedTime: Move Back {elapsedTime}");
            yield return null; // Wait for the next frame
        }

        // Ensure the attackPrefab reaches the target position
        attackPrefab.transform.position = targetPosition;

    }


    private IEnumerator Cooldown(God god)
    {
        yield return new WaitForSeconds(cooldownDuration);
        god.canAttack = true; // Reset canAttack flag after cooldown
    }

}

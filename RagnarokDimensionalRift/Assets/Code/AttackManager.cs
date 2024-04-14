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

    private float cooldownDuration = 1f; // Cooldown duration in seconds
    private float offsetDuration = 3f; // Offset duration between attacks in seconds
    private List<GameObject> Team1Prefabs = new List<GameObject>();
    private List<GameObject> Team2Prefabs = new List<GameObject>();
    private List<GameObject> Holder = new List<GameObject>();

    private List<GameObject> AttackOrderPrefabs = new List<GameObject>();
    private List<GameObject> Team1AttackOrderPrefabs= new List<GameObject>();
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

    public void StartBattle(List<GameObject> team1, List<GameObject> team2)
    {
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
            }else if (Team2AttackOrderPrefabs.Count() <= 0)
            {
                battleInProgress = false;
                Debug.Log("Victory");
                yield break;
            }

            if(godToAttack.health> 0)
            {
                bool attack = godToAttack.attacking;
                if(attack)
                {
                    if(Team2AttackOrderPrefabs[0] != null)
                    {
                        defendPrefab = Team2AttackOrderPrefabs[0];
                    }else if(Team2AttackOrderPrefabs.Count() <= 0)
                    {
                        defendPrefab= null;
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
        Vector3 offset;
        if (defendGod.attacking)
        {
            offset = new Vector3(-30f, 0f, 0f);
        }
        else
        {
            offset = new Vector3(30f, 0f, 0f);
        }
        Vector3 convertDefendPositon = new Vector3(defendGod.position.x, defendGod.position.y, 0f); ;
        Vector3 targetPosition = convertDefendPositon + offset;
        Debug.Log($"targetPositon {targetPosition}");
        

        // Duration of the movement
        float moveDuration = 1f;

        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            attackPrefab.transform.position = Vector3.Lerp(attackPrefab.transform.position, targetPosition, elapsedTime / moveDuration);
            Debug.Log($"small move to {attackPrefab.transform.position}");
            elapsedTime += Time.deltaTime; // DEBUG: Math is causing sprites to go off screen
            yield return null; // Wait for the next frame
        }

        Debug.Log($"Before setting target pos: {attackPrefab.transform.position}");

        // Ensure the attackPrefab reaches the target position
        attackPrefab.transform.position = targetPosition;

        Debug.Log($"After setting target pos: {attackPrefab.transform.position}");


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
                if(defendingGod.attacking)
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

        StartCoroutine(MoveBack(attackPrefab));
    }

    private IEnumerator MoveBack(GameObject attackPrefab)
    {
        Debug.Log("Moving back now!");
        

        // Initial and target positions
        Vector3 initialPosition = attackPrefab.transform.position;

        SetGodOnPrefab attackingGodScript = attackPrefab.GetComponent<SetGodOnPrefab>();
        God attackingGod = attackingGodScript.getGod();

        Vector3 targetPosition = new Vector3(attackingGod.position.x, attackingGod.position.y, 0f); ;

        Debug.Log($"targetPosition moving back to {targetPosition}");

        // Duration of the movement
        float moveDuration = 0.2f;

        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            attackPrefab.transform.position = Vector3.Lerp(attackPrefab.transform.position, targetPosition, elapsedTime / moveDuration);
            Debug.Log($"small move back to {attackPrefab.transform.position}");
            elapsedTime += Time.deltaTime;
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

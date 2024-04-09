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
    private float offsetDuration = 0.2f; // Offset duration between attacks in seconds
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

    /*
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
    */

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
            //GameObject defendPrefab = new GameObject();

            if(godToAttack.health> 0)
            {
                bool attack = godToAttack.attacking;
                if(attack)
                {
                    /*
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
                    */
                    defendPrefab = Team2AttackOrderPrefabs[0];

                }
                else
                {
                    /*
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
                    */
                    defendPrefab = Team1AttackOrderPrefabs[0];
                }

                // Initiate attack for the god
                StartCoroutine(Move(attackPrefab, defendPrefab));

                // Move to the next prefab in the list
                currentIndex = (currentIndex + 1) % totalPrefabs;

                // Wait for offset duration before next attack
                yield return new WaitForSeconds(offsetDuration);
                yield return null;
            }
            
        }
    }

    private IEnumerator Move(GameObject attackPrefab, GameObject defendPrefab)
    {
        // Initial and target positions
        Vector3 initialPosition = attackPrefab.transform.position;
        Vector3 targetPosition = defendPrefab.transform.position;

        // Duration of the movement
        float moveDuration = 0.2f;

        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            attackPrefab.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the attackPrefab reaches the target position
        attackPrefab.transform.position = targetPosition;

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
        // Initial and target positions
        Vector3 initialPosition = attackPrefab.transform.position;

        SetGodOnPrefab attackingGodScript = attackPrefab.GetComponent<SetGodOnPrefab>();
        God attackingGod = attackingGodScript.getGod();

        Vector3 targetPosition = attackingGod.position;

        // Duration of the movement
        float moveDuration = 0.2f;

        // Elapsed time
        float elapsedTime = 0f;

        // Move the attackPrefab towards the defendPrefab's position
        while (elapsedTime < moveDuration)
        {
            attackPrefab.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
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

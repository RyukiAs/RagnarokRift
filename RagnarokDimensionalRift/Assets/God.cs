using System.Buffers.Text;
using TMPro;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class God
{
    public string godName;
    public int grade;
    public Sprite icon;
    public int level;
    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
    public int health;
    public int attack;
    public int defense;
    public string description;
    public Sprite sprite;
    public Vector2 position; //Vector2?

    public God(string godName, int grade, Sprite icon, string description, Sprite sprite)
    {
        this.godName = godName;
        this.grade = grade;
        this.icon = icon;
        this.level = 1;
        this.baseHealth = 1000;
        this.health = this.baseHealth;
        this.baseAttack = 75;
        this.attack = this.baseAttack;
        this.baseDefense = 40;
        this.defense = this.baseDefense;
        this.description = description;
        this.sprite = sprite;
        this.position = new Vector2(0f,0f);
    }

    public void CalculateUpgradedStats(int level)
    {
        // Calculate upgraded stats using the base stats and growth rates
        // Adjust these formulas based on your desired calculations
        int hp = this.baseHealth * this.grade;
        int defense = this.baseDefense * this.grade;
        int attack = this.baseAttack * this.grade;

        float percentBonus = this.grade * (2.0f / 100);
        float percentFinal = 1 + percentBonus;
        int exponent = this.level - 1;
        float multiply = Mathf.Pow(percentFinal, exponent);

        float hpResult = hp * multiply;
        float defResult = defense * multiply;
        float attackResult = attack * multiply;

        this.health = (int)hpResult;
        this.attack = (int)attackResult;
        this.defense = (int)defResult;
        
    }

    public void attackFunction(God attackingGod, God defendingGod, GameObject attackingPrefab, GameObject defendingPrefab)
    {

        int damage = attackingGod.attack - defendingGod.defense;
        int newhealth = defendingGod.health - damage;
        Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName} for {damage} damage.");
        defendingGod.health= newhealth;
        

    }
    public void MoveAndAttack(God attackingGod, God defendingGod, GameObject attackingPrefab, GameObject defendingPrefab)
    {
        // Calculate the initial position of the attacking prefab
        /*
        Vector2 initialPosition = attackingPrefab.transform.position;
        Vector3 offset = new Vector3(10f, 0f, 0f);
        Vector2 targetPosition = defendingPrefab.transform.position + offset;
        float moveDuration = 3f;

        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            // Calculate the current position based on the interpolation factor
            float t = elapsedTime / moveDuration;
            Vector2 currentPosition = Vector2.Lerp(initialPosition, targetPosition, t);

            // Move the attacking prefab towards the target position smoothly over time
            attackingPrefab.transform.position = currentPosition;

            // Update elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Ensure that the attacking prefab reaches the target position exactly
        attackingPrefab.transform.position = targetPosition;

        // Perform the attack after the movement is completed
        attackFunction(attackingGod, defendingGod, attackingPrefab, defendingPrefab);
        */

    }

    

}
